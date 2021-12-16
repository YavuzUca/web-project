namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Newtonsoft.Json;

    public partial class Boat_Info
    {
        public int Id { get; set; }

        public double? longitude { get; set; }

        public double? latitude { get; set; }

        public double? temperature { get; set; }

        public int? wind_Direction { get; set; }

        public int? wind_Speed { get; set; }

        public int? boat_Speed { get; set; }

        public DateTime? Date_Time { get; set; }
    }

    public class Rock7
    {
        [JsonProperty("@context")]
        public string context { get; set; }

        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }

        [JsonProperty("@hydra:member")]
        public Rock7It[] items { get; set; }

        [JsonProperty("@hydra:membercount")]
        public int count { get; set; }
    }

    public class Rock7It
    {
        [JsonProperty("@id")]
        public string idString { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("direction")]
        public string direction { get; set; }

        [JsonProperty("dateReceived")]
        public string dateReceived { get; set; }

        [JsonProperty("dateSent")]
        public string dateSent { get; set; }

        [JsonProperty("sourceLatitude")]
        public float sourceLatitude { get; set; }

        [JsonProperty("sourceLongitude")]
        public float sourceLongitude { get; set; }

        [JsonProperty("destinationLatitude")]
        public float destinationLatitude { get; set; }

        [JsonProperty("destinationLongitude")]
        public float destinationLongitude { get; set; }

        [JsonProperty("temp1")]
        public float temp1 { get; set; }

        [JsonProperty("temp2")]
        public float temp2 { get; set; }

        [JsonProperty("waterPolution")]
        public float[] waterPolution { get; set; }

        [JsonProperty("heel")]
        public float heel { get; set; }

        [JsonProperty("rudder")]
        public float rudder { get; set; }

        [JsonProperty("sail")]
        public float sail { get; set; }

        [JsonProperty("course")]
        public float course { get; set; }

        [JsonProperty("windDirection")]
        public float windDirection { get; set; }

        [JsonProperty("speed")]
        public float speed { get; set; }

        [JsonProperty("gyroscope")]
        public float[] gyroscope { get; set; }

        [JsonProperty("controlLevel")]
        public float controlLevel { get; set; }
    }
    public class WeatherForecastModel
    {
        public DayForecastModel[] consolidated_weather { get; set; }
        public DateTime sun_rise { get; set; }
        public DateTime sun_set { get; set; }
        public string title { get; set; }
        public string timezone { get; set; }
    }

    public class DayForecastModel
    {
        public string weather_state_name { get; set; }
        public string applicable_date { get; set; }
        public float min_temp { get; set; }
        public float max_temp { get; set; }
    }
}
