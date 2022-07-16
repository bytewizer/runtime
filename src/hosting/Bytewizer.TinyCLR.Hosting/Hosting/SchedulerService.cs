//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Threading;

#if NanoCLR
namespace nanoFramework.Hosting
#else
namespace Bytewizer.TinyCLR.Hosting
#endif
{
    /// <summary>
    /// Base class timer service which calls an asynchronous action after the configured interval.
    /// </summary>
    public abstract class SchedulerService : IHostedService, IDisposable
    {
        private Timer _executeTimer;

        /// <summary>
        /// Schedules the immediate execution of <see cref="ExecuteAsync"/> on the provided interval.
        /// </summary>
        /// <param name="interval">The <see cref="TimeSpan"/> interval scheduler will execute on.</param>
        protected SchedulerService(TimeSpan interval)
        {
            Interval = interval;
            Time = TimeSpan.Zero;
        }

        /// <summary>
        /// Schedules the execution of <see cref="ExecuteAsync"/> on the provided interval.
        /// </summary>
        /// <param name="hour">The hour the scheduler will start on.</param>
        /// <param name="min">The miniute the scheduler will start on.</param>
        /// <param name="interval">The <see cref="TimeSpan"/> interval scheduler will execute on.</param>
        protected SchedulerService(int hour, int min, TimeSpan interval)
        {
            Interval = interval;

            DateTime now = DateTime.UtcNow;
            DateTime initialRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);

            if (now > initialRun)
            {
                initialRun = initialRun.AddDays(1);
            }

            Time = initialRun - now;

            if (Time <= TimeSpan.Zero)
            {
                Time = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Gets the due time of the timer. 
        /// </summary>
        protected TimeSpan Time { get; private set; }

        /// <summary>
        /// Gets the interval of the timer.
        /// </summary>
        protected TimeSpan Interval { get; private set; }

        /// <summary>
        /// Gets the <see cref="Timer"/> that executes the background operation.
        /// </summary>
        /// <remarks>
        /// Will return <see langword="null"/> if the background operation hasn't started.
        /// </remarks>
        public virtual Timer ExecuteTimer() => _executeTimer;

        /// <summary>
        /// This method is called each time the timer elapses. 
        /// </summary>
        protected abstract void ExecuteAsync();

        /// <inheritdoc />
        public virtual void Start()
        {
            // Store the timer we're executing
            _executeTimer = new Timer(state =>
            {
                ExecuteAsync();
            }, null, Time, Interval);
        }

        /// <inheritdoc />
        public virtual void Stop()
        {
            if (_executeTimer == null)
            {
                return;
            }

            try
            {
                _executeTimer.Change(Timeout.Infinite, 0);
            }
            finally
            {
                _executeTimer = null;
            }
        }

        /// <inheritdoc />
        public virtual void Dispose()
        {
            _executeTimer?.Dispose();
        }
    }
}
