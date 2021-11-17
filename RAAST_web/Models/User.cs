namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string fullName { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [Required]
        public string passWord_hash { get; set; }
    }
}
