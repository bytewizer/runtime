using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// The provider for the <see cref="SerialLogger"/>.
    /// </summary>
    public class SerialLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _minLevel;
        private readonly UartController _uartController;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLoggerProvider"/> class that
        /// is enabled for <see cref = "LogLevel" /> Information or higher.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        public SerialLoggerProvider(UartController controller)
        {
            _uartController = controller;
            _minLevel = LogLevel.Information;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLoggerProvider"/> class.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        /// <param name="minLevel">The minimum level of log messages if none of the rules match.</param>
        public SerialLoggerProvider(UartController controller, LogLevel minLevel)
        {
            _uartController = controller;
            _minLevel = minLevel;
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string name)
        {
            return new SerialLogger(_uartController, name, _minLevel);
        }

        /// <summary>
        /// Pro-actively frees resources owned by this instance.
        /// </summary>
        public void Dispose()
        {
            _uartController.Dispose();
        }
    }
}
