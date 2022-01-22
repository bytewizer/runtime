using System;

#if NanoCLR

namespace Bytewizer.NanoCLR
#else
namespace Bytewizer.TinyCLR
#endif
{
    /// <summary>
    /// Contains extension methods for <see cref="DateTime"/> object.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Defines the epoch.
        /// </summary>
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Converts to a <see cref="DateTime"/> from epoch (ISO 8601) datetime.
        /// </summary>
        /// <param name="unixTime">The epoch milliseconds to convert.<see cref="double"/></param>
        public static DateTime FromEpoch(this double unixTime)
        {
            return _epoch.AddMilliseconds(unixTime);
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> to epoch (ISO 8601) datetime.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to convert</param>
        public static double ToEpoch(this DateTime date)
        {
            return date.Subtract(_epoch).TotalMilliseconds;
        }
    }
}