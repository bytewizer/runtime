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
/// Base class for implementing a scheduler <see cref="IHostedService"/>.
/// </summary>
    public abstract class SchedulerService : IHostedService, IDisposable
    {
        private TimeSpan _time;
        private Timer _executeTimer;
        private readonly TimeSpan _interval;

        /// <summary>
        /// Schedules the immediate execution of <see cref="ExecuteAsync"/> on the provided interval.
        /// </summary>
        /// <param name="interval">The <see cref="TimeSpan"/> interval scheduler will execute on.</param>
        protected SchedulerService(TimeSpan interval)
        {
            _interval = interval;
            _time = TimeSpan.Zero;
        }

        /// <summary>
        /// Schedules the execution of <see cref="ExecuteAsync"/> on the provided interval.
        /// </summary>
        /// <param name="hour">The hour the scheduler will start on.</param>
        /// <param name="min">The miniute the scheduler will start on.</param>
        /// <param name="interval">The <see cref="TimeSpan"/> interval scheduler will execute on.</param>
        protected SchedulerService(int hour, int min, TimeSpan interval)
        {
            _interval = interval;

            DateTime now = DateTime.UtcNow;
            DateTime initialRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);

            if (now > initialRun)
            {
                initialRun = initialRun.AddDays(1);
            }

            _time = initialRun - now;

            if (_time <= TimeSpan.Zero)
            {
                _time = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// This method is called when the <see cref="IHostedService"/> starts. The implementation should return a thread that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="state">An object containing information to be used by the callback method, or null.</param>
        protected abstract void ExecuteAsync(object state);

        /// <inheritdoc />
        public virtual void StartAsync()
        {
            _executeTimer = new Timer(state =>
            {
                ExecuteAsync(state);
            }, _executeTimer, _time, _interval);
        }

        /// <inheritdoc />
        public virtual void StopAsync()
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
