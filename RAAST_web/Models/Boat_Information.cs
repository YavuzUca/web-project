namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Boat_Information
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string module_name { get; set; }

        [StringLength(50)]
        public string module_value { get; set; }

        public DateTime? time_date { get; set; }
    }
}
