// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Microsoft.Extensions.Logging;
using Windows.Win32;
using Windows.Win32.Networking.HttpServer;
using Windows.Win32.Security;

namespace Microsoft.AspNetCore.Server.HttpSys;

internal sealed partial class RequestQueue
{
    private readonly RequestQueueMode _mode;
    private readonly ILogger _logger;
    private bool _disposed;

    internal RequestQueue(string requestQueueName, ILogger logger)
        : this(requestQueueName, RequestQueueMode.Attach, securityDescriptor: null, logger, receiver: true)
    {
    }

    internal RequestQueue(string? requestQueueName, RequestQueueMode mode, GenericSecurityDescriptor? securityDescriptor, ILogger logger)
        : this(requestQueueName, mode, securityDescriptor, logger, false)
    { }

    private RequestQueue(string? requestQueueName, RequestQueueMode mode, GenericSecurityDescriptor? securityDescriptor, ILogger logger, bool receiver)
    {
        _mode = mode;
        _logger = logger;

        var flags = 0u;
        Created = true;

        SECURITY_ATTRIBUTES? securityAttributes = null;
        nint? pSecurityDescriptor = null;

        if (_mode == RequestQueueMode.Attach)
        {
            flags = PInvoke.HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING;
            Created = false;
            if (receiver)
            {
                flags |= PInvoke.HTTP_CREATE_REQUEST_QUEUE_FLAG_DELEGATION;
            }
        }
        else if (securityDescriptor is not null) // Create or CreateOrAttach
        {
            // Convert the security descriptor to a byte array
            byte[] securityDescriptorBytes = new byte[securityDescriptor.BinaryLength];
            securityDescriptor.GetBinaryForm(securityDescriptorBytes, 0);

            // Allocate native memory for the security descriptor
            pSecurityDescriptor = Marshal.AllocHGlobal(securityDescriptorBytes.Length);
            Marshal.Copy(securityDescriptorBytes, 0, pSecurityDescriptor.Value, securityDescriptorBytes.Length);

            unsafe
            {
                securityAttributes = new SECURITY_ATTRIBUTES
                {
                    nLength = (uint)Marshal.SizeOf<SECURITY_ATTRIBUTES>(),
                    lpSecurityDescriptor = pSecurityDescriptor.Value.ToPointer(),
                    bInheritHandle = false
                };
            }
        }

        var statusCode = PInvoke.HttpCreateRequestQueue(
                HttpApi.Version,
                requestQueueName,
                securityAttributes,
                flags,
                out var requestQueueHandle);

        if (_mode == RequestQueueMode.CreateOrAttach && statusCode == ErrorCodes.ERROR_ALREADY_EXISTS)
        {
            // Tried to create, but it already exists so attach to it instead.
            Created = false;
            flags = PInvoke.HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING;
            statusCode = PInvoke.HttpCreateRequestQueue(
                    HttpApi.Version,
                    requestQueueName,
                    SecurityAttributes: default, // Attaching should not pass any security attributes
                    flags,
                    out requestQueueHandle);
        }

        if (pSecurityDescriptor is not null)
        {
            // Free the allocated memory for the security descriptor
            Marshal.FreeHGlobal(pSecurityDescriptor.Value);
        }

        if ((flags & PInvoke.HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING) != 0 && statusCode == ErrorCodes.ERROR_FILE_NOT_FOUND)
        {
            throw new HttpSysException((int)statusCode, $"Failed to attach to the given request queue '{requestQueueName}', the queue could not be found.");
        }
        else if (statusCode == ErrorCodes.ERROR_INVALID_NAME)
        {
            throw new HttpSysException((int)statusCode, $"The given request queue name '{requestQueueName}' is invalid.");
        }
        else if (statusCode != ErrorCodes.ERROR_SUCCESS)
        {
            throw new HttpSysException((int)statusCode);
        }

        // Disabling callbacks when IO operation completes synchronously (returns ErrorCodes.ERROR_SUCCESS)
        if (HttpSysListener.SkipIOCPCallbackOnSuccess &&
            !PInvoke.SetFileCompletionNotificationModes(
                requestQueueHandle,
                (byte)(PInvoke.FILE_SKIP_COMPLETION_PORT_ON_SUCCESS |
                PInvoke.FILE_SKIP_SET_EVENT_ON_HANDLE)))
        {
            requestQueueHandle.Dispose();
            throw new HttpSysException(Marshal.GetLastWin32Error());
        }

        Handle = requestQueueHandle;
        BoundHandle = ThreadPoolBoundHandle.BindHandle(Handle);

        if (!Created)
        {
            Log.AttachedToQueue(_logger, requestQueueName);
        }
    }

    /// <summary>
    /// True if this instace created the queue instead of attaching to an existing one.
    /// </summary>
    internal bool Created { get; }

    internal SafeHandle Handle { get; }
    internal ThreadPoolBoundHandle BoundHandle { get; }

    // The listener must be active for this to work.
    internal unsafe void SetLengthLimit(long length)
    {
        Debug.Assert(Created);
        CheckDisposed();

        var result = PInvoke.HttpSetRequestQueueProperty(Handle,
            HTTP_SERVER_PROPERTY.HttpServerQueueLengthProperty,
            &length, (uint)Marshal.SizeOf<long>());

        if (result != 0)
        {
            throw new HttpSysException((int)result);
        }
    }

    // The listener must be active for this to work.
    internal unsafe void SetRejectionVerbosity(Http503VerbosityLevel verbosity)
    {
        Debug.Assert(Created);
        CheckDisposed();

        var result = PInvoke.HttpSetRequestQueueProperty(Handle,
            HTTP_SERVER_PROPERTY.HttpServer503VerbosityProperty,
            &verbosity, (uint)Marshal.SizeOf<long>());

        if (result != 0)
        {
            throw new HttpSysException((int)result);
        }
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        PInvoke.HttpCloseRequestQueue(Handle);

        BoundHandle.Dispose();
        Handle.Dispose();
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }

    private static partial class Log
    {
        [LoggerMessage(LoggerEventIds.AttachedToQueue, LogLevel.Information, "Attached to an existing request queue '{RequestQueueName}', some options do not apply.", EventName = "AttachedToQueue")]
        public static partial void AttachedToQueue(ILogger logger, string? requestQueueName);
    }
}
