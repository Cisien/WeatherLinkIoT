using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherLinkClient;
using Microsoft.Extensions.Logging.Console;
using System;

namespace WeatherLinkIoT
{
    class Program
    {

        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddEnvironmentVariables("IOT_");
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddUserSecrets("8ca2dfc3-5f38-489d-ac1b-328c9df9b0bf");
                    }
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddSimpleConsole(o =>
                    {
                        o.ColorBehavior = LoggerColorBehavior.Default;
                        o.SingleLine = true;
                        o.TimestampFormat = "yyyy-MM-ddThh:mm:ss.fffzzzz ";
                        o.IncludeScopes = true;
                    });
                })
                .ConfigureServices((context, builder) =>
                {
                    builder.AddHttpClient();
                    builder.AddSingleton<WeatherLinkLiveClient, WeatherLinkLiveClient>();
                    builder.AddSingleton<DeviceClientFactory, DeviceClientFactory>();
                    builder.AddHostedService<WeatherIotService>();
                });

            using var builtHost = host.Build();
            await builtHost.RunAsync();
        }
    }
}
