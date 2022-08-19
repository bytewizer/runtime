// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using System.Collections;

#if NanoCLR

using Bytewizer.NanoCLR.DependencyInjection;

namespace Bytewizer.NanoCLR.Logging
#else
using Bytewizer.TinyCLR.DependencyInjection;

namespace Bytewizer.TinyCLR.Logging
#endif
{
    /// <summary>
    /// Produces instances of <see cref="ILogger"/> classes based on the given providers.
    /// </summary>
    public class LoggerFactory : ILoggerFactory
    {
        private readonly Hashtable _loggers;
        private readonly ArrayList _providers;
        private readonly LoggerFilterOptions _filterOptions;

        private bool _disposed;
        private readonly object _syncLock = new object();

        /// <summary>
        /// Creates a new <see cref="LoggerFactory"/> instance.
        /// </summary>
        /// <param name="service">The <see cref="IServiceProvider"/> use in producing <see cref="ILogger"/> instances.</param>
        /// <param name="filterOption">The filter option to use.</param>
        public LoggerFactory(IServiceProvider service, LoggerFilterOptions filterOption)
        {
            _loggers = new Hashtable();
            _providers = new ArrayList();

            var services = service.GetServices(new Type[] { typeof(ILoggerProvider) });
            foreach (var provider in services)
            {
                _providers.Add(provider);
            }

            _filterOptions = filterOption;
        }

        /// <summary>
        /// Adds the given provider to those used in creating <see cref="ILogger"/> instances.
        /// </summary>
        /// <param name="provider">The <see cref="ILoggerProvider"/> to add.</param>
        public void AddProvider(ILoggerProvider provider)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException();
            }

            lock (_syncLock)
            {
                _providers.Add(provider);
            }
        }

        /// <summary>
        /// Creates an <see cref="ILogger"/> with the given <paramref name="categoryName"/>.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns>The <see cref="ILogger"/> that was created.</returns>
        public ILogger CreateLogger(string categoryName)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException();
            }

            lock (_syncLock)
            {
                var logger = new Logger()
                {
                    Loggers = CreateLoggers(categoryName)
                };

                logger.MessageLoggers = CreateMessageLoggers(logger.Loggers);
                _loggers[categoryName] = logger;

                return logger;
            }
        }

        private MessageLogger[] CreateMessageLoggers(LoggerInformation[] loggers)
        {
            var messageLoggers = new MessageLogger[loggers.Length];
            var minLevel = _filterOptions.MinLevel;

            for (int index = 0; index < loggers.Length; index++)
            {
                if (minLevel > LogLevel.Critical)
                {
                    continue;
                }

                messageLoggers[index] = new MessageLogger(
                        loggers[index].Logger, loggers[index].Category, minLevel
                    );
            }

            return messageLoggers;
        }

        private LoggerInformation[] CreateLoggers(string categoryName)
        {
            var loggers = new LoggerInformation[_providers.Count];

            for (var index = 0; index < _providers.Count; index++)
            {
                loggers[index] = new LoggerInformation((ILoggerProvider)_providers[index], categoryName);
            }

            return loggers;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            for (int index = _providers.Count - 1; index >= 0; index--)
            {
                if (_providers[index] is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}
