using Microsoft.Azure.Devices.Client;
using System;

namespace WeatherLinkIoT
{
    public class AlwaysRetryPolicy : IRetryPolicy
    {
        public bool ShouldRetry(int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
        {
            retryInterval = TimeSpan.FromMilliseconds(500);
            return true;
        }
    }
}
