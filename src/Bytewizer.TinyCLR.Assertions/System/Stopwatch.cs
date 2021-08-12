using System;

namespace System.Diagnostics
{
    /// <summary>
    /// Provides a set of methods and properties that you can use to accurately measure elapsed time.
    /// </summary>
    public class Stopwatch
    {
        private long startTicks = 0;
        private long stopTicks = 0;
        private bool isRunning = false;

        private const long m_ticksPerMillisecond = TimeSpan.TicksPerMillisecond;

        /// <summary>
        /// Initializes a new <see cref="Stopwatch"/> instance, sets the elapsed time property to zero, and starts measuring elapsed time.
        /// </summary>
        /// <returns>A <see cref="Stopwatch"/> that has just begun measuring elapsed time.</returns>
        public static Stopwatch StartNew()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            return stopwatch;
        }

        private Stopwatch()
        {
        }

        /// <summary>
        /// Stops time interval measurement and resets the elapsed time to zero.
        /// </summary>
        public void Reset()
        {
            startTicks = 0;
            stopTicks = 0;
            isRunning = false;
        }

        /// <summary>
        /// Starts, or resumes, measuring elapsed time for an interval.
        /// </summary>
        public void Start()
        {
            if (startTicks != 0 && stopTicks != 0)
                startTicks = DateTime.Now.Ticks - (stopTicks - startTicks); 
            else
                startTicks = DateTime.Now.Ticks; 
            isRunning = true;
        }

        /// <summary>
        /// Stops measuring elapsed time for an interval.
        /// </summary>
        public void Stop()
        {
            stopTicks = DateTime.Now.Ticks;
            isRunning = false;
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in milliseconds.
        /// </summary>
        public long ElapsedMilliseconds
        {
            get
            {
                if (startTicks != 0 && isRunning)
                    return (DateTime.Now.Ticks - startTicks) / m_ticksPerMillisecond;
                else if (startTicks != 0 && !isRunning)
                    return (stopTicks - startTicks) / m_ticksPerMillisecond;
                else
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in seconds.
        /// </summary>
        public double ElapsedSeconds
        {
            get
            {
                if (startTicks != 0 && isRunning)
                {
                    TimeSpan duration = new TimeSpan((DateTime.Now.Ticks - startTicks));
                    return duration.Seconds;
                }
                else if (startTicks != 0 && !isRunning)
                {
                    TimeSpan duration = new TimeSpan((stopTicks - startTicks));
                    return duration.Seconds;
                }
                else
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in minutes.
        /// </summary>
        public double ElapsedMinutes
        {
            get
            {
                if (startTicks != 0 && isRunning)
                {
                    TimeSpan duration = new TimeSpan(DateTime.Now.Ticks - startTicks);
                    return duration.Minutes;
                }
                else if (startTicks != 0 && !isRunning)
                {
                    TimeSpan duration = new TimeSpan(stopTicks - startTicks);
                    return duration.Minutes;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
