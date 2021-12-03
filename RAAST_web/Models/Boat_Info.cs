namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
}
