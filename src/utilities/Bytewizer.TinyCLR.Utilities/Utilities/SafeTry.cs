using System;
using System.Threading;

namespace Bytewizer.TinyCLR.Utilities
{
    public class SafeTry
    {
		public delegate bool RetryAction();

		public static void RetryUntilTrue(RetryAction action, TimeSpan timeOut)
		{
			var i = 0;
			var firstAttempt = DateTime.Now;

			while (DateTime.Now - firstAttempt < timeOut)
			{
				i++;
				if (action())
				{
					return;
				}
				SleepBackOffMultiplier(i);
			}

			throw new Exception(string.Format("Exceeded timeout of {0}", timeOut));
		}

		public static void RetryOnException(Action action, TimeSpan timeOut)
		{
			var i = 0;
			Exception lastEx = null;
			var firstAttempt = DateTime.Now;

			while (DateTime.Now - firstAttempt < timeOut)
			{
				i++;
				try
				{
					action();
					return;
				}
				catch (Exception ex)
				{
					lastEx = ex;

					SleepBackOffMultiplier(i);
				}
			}

			throw new Exception(string.Format("Exceeded timeout of {0}", timeOut), lastEx);
		}

		public static void RetryOnException(Action action, int maxRetries)
		{
			for (var i = 0; i < maxRetries; i++)
			{
				try
				{
					action();
					break;
				}
				catch
				{
					if (i == maxRetries - 1) throw;

					SleepBackOffMultiplier(i);
				}
			}
		}

		private static void SleepBackOffMultiplier(int i)
		{
			var rand = new Random(Guid.NewGuid().GetHashCode());
			var nextTry = rand.Next((int)Math.Pow(i + 1, 2) + 1);

			Thread.Sleep(nextTry);
		}
	}
}
