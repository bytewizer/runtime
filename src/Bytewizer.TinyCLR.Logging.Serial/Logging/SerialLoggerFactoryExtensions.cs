// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using GHIElectronics.TinyCLR.Devices.Uart;

namespace Bytewizer.TinyCLR.Logging.Serial
{
    /// <summary>
    /// Extension methods for the <see cref="ILoggerFactory"/> class.
    /// </summary>
    public static class SerialLoggerFactoryExtensions
    {
        /// <summary>
        /// Adds a serial logger that is enabled for <see cref="LogLevel"/> Information or higher.
        /// </summary>
        /// <param name="factory">The extension method argument.</param>
        /// <param name="name">The serial controller port name to use.</param>
        public static ILoggerFactory AddSerial(this ILoggerFactory factory, string name)
        {
            return AddSerial(factory, name, LogLevel.Information);
        }

        /// <summary>
        /// Adds a serial logger that is enabled as defined by the filter function.
        /// </summary>
        /// <param name="factory">The extension method argument.</param>
        /// <param name="name">The serial controller port name to use.</param>
        /// <param name="minLevel">The minimum <see cref="LogLevel"/> to be logged.</param>
        public static ILoggerFactory AddSerial(this ILoggerFactory factory, string name, LogLevel minLevel)
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

            return AddSerial(factory, uartController, minLevel);
        }

        /// <summary>
        /// Adds a serial logger that is enabled for <see cref="LogLevel"/> Information or higher.
        /// </summary>
        /// <param name="factory">The extension method argument.</param>
        /// <param name="controller">The serial controller to use.</param>
        public static ILoggerFactory AddSerial(this ILoggerFactory factory, UartController controller)
        {
            return AddSerial(factory, controller, LogLevel.Information);
        }

        /// <summary>
        /// Adds a serial logger that is enabled as defined by the filter function.
        /// </summary>
        /// <param name="factory">The extension method argument.</param>
        /// <param name="controller">The serial controller to use.</param>
        /// <param name="minLevel">The minimum <see cref="LogLevel"/> to be logged.</param>
        public static ILoggerFactory AddSerial(this ILoggerFactory factory, UartController controller, LogLevel minLevel)
        {
            factory.AddProvider(new SerialLoggerProvider(controller, minLevel));
            return factory;
        }
    }
}