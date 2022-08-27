using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// The provider for the <see cref="SerialLogger"/>.
    /// </summary>
    public class SerialLoggerProvider : ILoggerProvider
    {
        private readonly UartController _uartController;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLoggerProvider"/> class.
        /// </summary>
        /// <param name="controller">The serial controller to use.</param>
        public SerialLoggerProvider(UartController controller)
        {
            _uartController = controller;
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string name)
        {
            return new SerialLogger(_uartController, name);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _uartController.Dispose();
        }
    }
}
