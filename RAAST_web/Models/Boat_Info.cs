namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;

    public partial class Boat_Info
    {
        public int Id { get; set; }
        public string idName { get; set; }

        public double? longitude { get; set; }

        public double? latitude { get; set; }

        public double? temperature { get; set; }

        public int? wind_Direction { get; set; }

        public int? wind_Speed { get; set; }

        public int? boat_Speed { get; set; }

        public string Date_Time { get; set; }
    }

    public class Rock7
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }

        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("hydra:member")]
        public List<Rock7It> Rock7Item { get; set; }

        [JsonPropertyName("hydra:totalItems")]
        public int Rock7TotalItems { get; set; }
    }

    public class Rock7It
    {
        [JsonPropertyName("@id")]
        public string IdString { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        [JsonPropertyName("dateReceived")]
        public string DateReceived { get; set; }

        [JsonPropertyName("dateSent")]
        public string DateSent { get; set; }

        [JsonPropertyName("sourceLatitude")]
        public double SourcaLat { get; set; }

        [JsonPropertyName("sourceLongitude")]
        public double SourceLon { get; set; }

        [JsonPropertyName("destinationLatitude")]
        public double DestinationLat { get; set; }

        [JsonPropertyName("destinationLongitude")]
        public double DestinationLon { get; set; }

        [JsonPropertyName("temp1")]
        public float Temp1 { get; set; }

        [JsonPropertyName("temp2")]
        public float Temp2 { get; set; }

        [JsonPropertyName("waterPolution")]
        public string WaterPolution { get; set; }

        [JsonPropertyName("heel")]
        public int Heel { get; set; }

        [JsonPropertyName("rudder")]
        public int Rudder { get; set; }

        [JsonPropertyName("sail")]
        public int Sail { get; set; }

        [JsonPropertyName("course")]
        public int course { get; set; }

        [JsonPropertyName("windDirection")]
        public int WindDirection { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }

        [JsonPropertyName("gyroscope")]
        public string Gyroscope { get; set; }
    }

    public class Weather
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }

        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("hydra:member")]
        public List<WeatherIt> WeatherItem { get; set; }

        [JsonPropertyName("hydra:totalItems")]
        public int Rock7TotalItems { get; set; }
    }
    public class WeatherIt
    {
        [JsonPropertyName("@id")]
        public string IdString { get; set; }

        [JsonPropertyName("@type")]
        public string type { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("time")]
        public DateTime time { get; set; }

        [JsonPropertyName("lat")]
        public double lat { get; set; }

        [JsonPropertyName("lon")]
        public double lon { get; set; }

        [JsonPropertyName("windSpeed")]
        public List<WindInfo> windInfo { get; set; }
    }

    public class WindInfo
    {
        [JsonPropertyName("icon")]
        public double icon { get; set; }

        [JsonPropertyName("noaa")]
        public double noaa { get; set; }

        [JsonPropertyName("sg")]
        public double sg { get; set; }
    }

    public class DayForecastModel
    {
        public string weather_state_name { get; set; }
        public string applicable_date { get; set; }
        public float min_temp { get; set; }
        public float max_temp { get; set; }
    }
}
