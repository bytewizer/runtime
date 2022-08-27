using System;
using System.Text;
using System.Threading;

using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// A logger that writes messages in the debug output window only when a debugger is attached.
    /// </summary>
    internal partial class SerialLogger : ILogger
    {
        private readonly string _name;
        private readonly UartController _uartController;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLogger"/> class.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        /// <param name="name">The name of the logger.</param>
        public SerialLogger(UartController controller, string name)
        {
            _uartController = controller;
            _name = string.IsNullOrEmpty(name) ? nameof(SerialLogger) : name;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return _uartController != null &&
                logLevel != LogLevel.None; 
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

            var sb = new StringBuilder();

            sb.Append(LogLevelString.GetName(logLevel));
            sb.Append(": ");
            sb.Append(_name);
            sb.Append("[");
            sb.Append(eventId.Id);
            sb.Append("]");
            sb.Append(": ");
            sb.Append(message);

            if (exception != null)
            {
                sb.Append(": ");
                sb.Append(exception);
            }

            sb.AppendLine();

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());

            ThreadPool.QueueUserWorkItem(
               new WaitCallback(delegate (object state)
               {
                   _uartController.Write(bytes);
               }));            
        }
    }
}
