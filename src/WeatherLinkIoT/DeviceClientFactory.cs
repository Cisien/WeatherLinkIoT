using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherLinkClient;

namespace WeatherLinkIoT
{
    public class DeviceClientFactory
    {
        private readonly IConfiguration _config;
        private readonly ILogger<WeatherLinkLiveClient> _logger;

        public DeviceClientFactory(IConfiguration config, ILogger<WeatherLinkLiveClient> logger)
        {
            _config = config;
            _logger = logger;
        }
        public async Task<DeviceClient> Create()
        {
            var client = DeviceClient.CreateFromConnectionString(_config["deviceConnectionString"]);
            client.SetRetryPolicy(new AlwaysRetryPolicy());
            client.SetConnectionStatusChangesHandler((status, reason) => _logger.LogInformation($"Connection Status Changed to {status} ({reason})"));
            _ = client.SetMethodDefaultHandlerAsync((request, client) => Task.FromResult(new MethodResponse(Array.Empty<byte>(), 200)), client);

            await client.OpenAsync();
            return client;
        }
    }
}