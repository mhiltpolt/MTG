using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MTG.CardMoth.Utils
{
    public static class RetryHelper
    {
        private static int[] _delayPerAttemptInSeconds = new int[] { (int) TimeSpan.FromSeconds(2).TotalSeconds, 
            (int) TimeSpan.FromSeconds(30).TotalSeconds, 
            (int) TimeSpan.FromMinutes(2).TotalSeconds, 
            (int) TimeSpan.FromMinutes(10).TotalSeconds, 
            (int) TimeSpan.FromMinutes(30).TotalSeconds 
        };

        public static async Task RetryOnExceptionAsync(int times, TimeSpan delay, Func<Task> operation)
        {
            await RetryOnExceptionAsync<Exception>(times, delay, operation);
        }

        public static async Task RetryOnExceptionAsync<TException>(int times, TimeSpan delay, Func<Task> operation) where TException : Exception
        {
            if (times <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(times));
            }

            int attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    await operation();
                    break;
                }
                catch (TException ex)
                {
                    if (attempts == times)
                    {
                        throw;
                    }
                    await CreateDelayForException(times, attempts, delay, ex);
                }
            } while (true);
        }

        private static Task CreateDelayForException(int times, int attempts, TimeSpan delay, Exception ex)
        {
            int newDelay = increasingDelayInSeconds(attempts);
            Debug.Print($"Exception on attempt {attempts} of {times}. " +
                      "Will retry after sleeping for {delay}.", ex);
            return Task.Delay(newDelay);
        }

        private static int increasingDelayInSeconds(int failedAttempts)
        {
            if (failedAttempts <= 0) throw new ArgumentOutOfRangeException();

            return failedAttempts > _delayPerAttemptInSeconds.Length ? _delayPerAttemptInSeconds.Last() : _delayPerAttemptInSeconds[failedAttempts];
        }
    }
}
