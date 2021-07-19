using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherLinkClient;

namespace WeatherLinkIoT
{
    public class WeatherIotService : IHostedService
    {
        private DeviceClient _deviceClient = null!;
        private readonly DeviceClientFactory _deviceClientFactory;
        private readonly WeatherLinkLiveClient _wllClient;
        private readonly ILogger<WeatherIotService> _logger;
        private readonly Timer _updateTimer;

        public WeatherIotService(DeviceClientFactory deviceClientFactory, WeatherLinkLiveClient wllClient, ILogger<WeatherIotService> logger)
        {
            _deviceClientFactory = deviceClientFactory;
            _wllClient = wllClient;
            _logger = logger;
            _updateTimer = new Timer(async (o) => await DoWeatherUpdate());
        }

        private async Task DoWeatherUpdate()
        {
            var now = DateTime.Now;
            var currentConditions = await _wllClient.GetCurrentConditionsAsync("http://weatherlinklive.local.cisien.com");
            var mainSensor = currentConditions?.Data.Conditions.SingleOrDefault(a => a.DataStructureType == 1);
            if (mainSensor == null)
            {
                _logger.LogWarning("WeatherLink failed to respond");
                return;
            }
            mainSensor.DateTime = DateTimeOffset.UtcNow;
            mainSensor.DeviceId = currentConditions!.Data.Did;

            foreach(var sensors in currentConditions.Data.Conditions.Where(a => a.DataStructureType != 1))
            {
                mainSensor.TempIn ??= sensors.TempIn;
                mainSensor.HumIn ??= sensors.HumIn;
                mainSensor.DewPointIn ??= sensors.DewPointIn;
                mainSensor.HeatIndexIn ??= sensors.HeatIndexIn;
                mainSensor.BarSeaLevel ??= sensors.BarSeaLevel;
                mainSensor.BarTrend ??= sensors.BarTrend;
                mainSensor.BarAbsolute ??= sensors.BarAbsolute;
            }

            var jsonData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(mainSensor));

            var message = new Message(jsonData)
            {
                ComponentName = "RealTimeWeather",
                ContentEncoding = "utf-8",
                ContentType = "application/json",
                CreationTimeUtc = DateTimeOffset.UtcNow.UtcDateTime,
                MessageId = Guid.NewGuid().ToString()
            };

            await _deviceClient.SendEventAsync(message);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _deviceClient = await _deviceClientFactory.Create();
            _updateTimer.Change(TimeSpan.FromMilliseconds(0), TimeSpan.FromSeconds(60));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _updateTimer.Change(Timeout.Infinite, Timeout.Infinite);
            return Task.CompletedTask;
        }
    }
}
