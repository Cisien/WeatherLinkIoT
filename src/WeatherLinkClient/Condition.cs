using System;
using System.Text.Json.Serialization;

namespace WeatherLinkClient
{
    public class Condition
    {
        [JsonPropertyName("DeviceId")]
        public string? DeviceId { get; set; }
        
        [JsonPropertyName("DateTime")]
        public DateTimeOffset DateTime { get; set; }

        [JsonPropertyName("lsid")]
        public decimal Lsid { get; set; }

        [JsonPropertyName("data_structure_type")]
        public decimal DataStructureType { get; set; }

        [JsonPropertyName("txid")]
        public decimal? Txid { get; set; }

        [JsonPropertyName("temp")]
        public decimal? Temp { get; set; }

        [JsonPropertyName("hum")]
        public decimal? Hum { get; set; }

        [JsonPropertyName("dew_point")]
        public decimal? DewPoint { get; set; }

        [JsonPropertyName("wet_bulb")]
        public decimal? WetBulb { get; set; }

        [JsonPropertyName("heat_index")]
        public decimal? HeatIndex { get; set; }

        [JsonPropertyName("wind_chill")]
        public decimal? WindChill { get; set; }

        [JsonPropertyName("thw_index")]
        public decimal? ThwIndex { get; set; }

        [JsonPropertyName("thsw_index")]
        public decimal? ThswIndex { get; set; }

        [JsonPropertyName("wind_speed_last")]
        public decimal? WindSpeedLast { get; set; }

        [JsonPropertyName("wind_dir_last")]
        public decimal? WindDirLast { get; set; }

        [JsonPropertyName("wind_speed_avg_last_1_min")]
        public decimal? WindSpeedAvgLast1_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_1_min")]
        public decimal? WindDirScalarAvgLast1_Min { get; set; }

        [JsonPropertyName("wind_speed_avg_last_2_min")]
        public decimal? WindSpeedAvgLast2_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_2_min")]
        public decimal? WindDirScalarAvgLast2_Min { get; set; }

        [JsonPropertyName("wind_speed_hi_last_2_min")]
        public decimal? WindSpeedHiLast2_Min { get; set; }

        [JsonPropertyName("wind_dir_at_hi_speed_last_2_min")]
        public decimal? WindDirAtHiSpeedLast2_Min { get; set; }

        [JsonPropertyName("wind_speed_avg_last_10_min")]
        public decimal? WindSpeedAvgLast10_Min { get; set; }

        [JsonPropertyName("wind_dir_scalar_avg_last_10_min")]
        public decimal? WindDirScalarAvgLast10_Min { get; set; }

        [JsonPropertyName("wind_speed_hi_last_10_min")]
        public decimal? WindSpeedHiLast10_Min { get; set; }

        [JsonPropertyName("wind_dir_at_hi_speed_last_10_min")]
        public decimal? WindDirAtHiSpeedLast10_Min { get; set; }

        [JsonPropertyName("rain_size")]
        public int? RainSize { get; set; }

        [JsonPropertyName("rain_rate_last")]
        public decimal? RainRateLast { get; set; }

        [JsonPropertyName("rain_rate_hi")]
        public decimal? RainRateHi { get; set; }

        [JsonPropertyName("rainfall_last_15_min")]
        public decimal? RainfallLast15_Min { get; set; }

        [JsonPropertyName("rain_rate_hi_last_15_min")]
        public decimal? RainRateHiLast15_Min { get; set; }

        [JsonPropertyName("rainfall_last_60_min")]
        public decimal? RainfallLast60_Min { get; set; }

        [JsonPropertyName("rainfall_last_24_hr")]
        public decimal? RainfallLast24_Hr { get; set; }

        [JsonPropertyName("rain_storm")]
        public decimal? RainStorm { get; set; }

        [JsonPropertyName("rain_storm_start_at")]
        public decimal? RainStormStartAt { get; set; }

        [JsonPropertyName("solar_rad")]
        public decimal? SolarRad { get; set; }

        [JsonPropertyName("uv_index")]
        public decimal? UvIndex { get; set; }

        [JsonPropertyName("rx_state")]
        public decimal? RxState { get; set; }

        [JsonPropertyName("trans_battery_flag")]
        public decimal? TransBatteryFlag { get; set; }

        [JsonPropertyName("rainfall_daily")]
        public decimal? RainfallDaily { get; set; }

        [JsonPropertyName("rainfall_monthly")]
        public decimal? RainfallMonthly { get; set; }

        [JsonPropertyName("rainfall_year")]
        public decimal? RainfallYear { get; set; }

        [JsonPropertyName("rain_storm_last")]
        public decimal? RainStormLast { get; set; }

        [JsonPropertyName("rain_storm_last_start_at")]
        public decimal? RainStormLastStartAt { get; set; }

        [JsonPropertyName("rain_storm_last_end_at")]
        public decimal? RainStormLastEndAt { get; set; }

        [JsonPropertyName("temp_in")]
        public decimal? TempIn { get; set; }

        [JsonPropertyName("hum_in")]
        public decimal? HumIn { get; set; }

        [JsonPropertyName("dew_point_in")]
        public decimal? DewPointIn { get; set; }

        [JsonPropertyName("heat_index_in")]
        public decimal? HeatIndexIn { get; set; }

        [JsonPropertyName("bar_sea_level")]
        public decimal? BarSeaLevel { get; set; }

        [JsonPropertyName("bar_trend")]
        public decimal? BarTrend { get; set; }

        [JsonPropertyName("bar_absolute")]
        public decimal? BarAbsolute { get; set; }
    }
}
