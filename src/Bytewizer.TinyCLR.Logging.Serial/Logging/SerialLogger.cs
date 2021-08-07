// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text;

using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// A logger that writes messages in the debug output window only when a debugger is attached.
    /// </summary>
    internal partial class SerialLogger : ILogger
    {
        private readonly UartController _uartController;
        private readonly string _name;
        private readonly LogLevel _minLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLogger"/> class.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        /// <param name="name">The name of the logger.</param>
        public SerialLogger(UartController controller, string name)
            : this(controller, name, LogLevel.Trace)
        {
            _uartController = controller;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLogger"/> class.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        /// <param name="name">The name of the logger.</param>
        /// <param name="minLevel">The minimum level of log messages to filter messages.</param>
        public SerialLogger(UartController controller, string name, LogLevel minLevel)
        {
            _uartController = controller;
            _name = string.IsNullOrEmpty(name) ? nameof(SerialLogger) : name;
            _minLevel = minLevel;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            // If the filter is null, everything is enabled
            // unless the debugger is not attached
            return _uartController != null &&
                logLevel != LogLevel.None &&
                LogFilter(logLevel);
        }

        private bool LogFilter(LogLevel logLevel)
        {
            if (_minLevel <= logLevel)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void Log(LogLevel logLevel, EventId eventId, object state, Exception exception)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = state.ToString();

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var builder = new StringBuilder();

            builder.Append(LogLevelString.GetName(logLevel));
            builder.Append(": ");
            builder.Append(_name);
            builder.Append("[");
            builder.Append(eventId.Id);
            builder.Append("]");
            builder.Append(": ");
            builder.Append(message);

            if (exception != null)
            {
                builder.Append(": ");
                builder.Append(exception);
            }

            builder.AppendLine();

            //TODO:  Add threaded write que

            var bytes = Encoding.UTF8.GetBytes(builder.ToString());

            _uartController.Write(bytes);
        }
    }
}
