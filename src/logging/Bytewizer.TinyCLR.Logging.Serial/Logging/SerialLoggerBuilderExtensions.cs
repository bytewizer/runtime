using Bytewizer.TinyCLR.DependencyInjection;

using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// Extension methods for the <see cref="ILoggingBuilder"/> class.
    /// </summary>
    public static class SerialLoggerBuilderExtensions
    {
        /// <summary>
        /// Adds a serial logger that is enabled as defined by the log level.
        /// </summary>
        /// <param name="builder">The extension method argument.</param>
        /// <param name="name">The serial controller port name to use.</param>
        public static ILoggingBuilder AddSerial(this ILoggingBuilder builder, string name)
        {
            var uartController = UartController.FromName(name);

            uartController.SetActiveSettings(new UartSetting()
            {
                BaudRate = 115200,
                DataBits = 8,
                Parity = UartParity.None,
                StopBits = UartStopBitCount.One,
                Handshaking = UartHandshake.None,
            });

            uartController.Enable();

            return AddSerial(builder, uartController);
        }

        /// <summary>
        /// Adds a serial logger that is enabled as defined by the log level.
        /// </summary>
        /// <param name="builder">The extension method argument.</param>
        /// <param name="controller">The serial controller to use.</param>
        public static ILoggingBuilder AddSerial(this ILoggingBuilder builder, UartController controller)
        {
            builder.Services.Add(new ServiceDescriptor(
                typeof(ILoggerProvider),
                new SerialLoggerProvider(controller))
            );

            return builder;
        }
    }
}