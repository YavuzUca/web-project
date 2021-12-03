namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Newsletter")]
    public partial class Newsletter
    {
        public int Id { get; set; }

        [DataType( DataType.EmailAddress )]
        [Required(ErrorMessage = "Enter an email-address. It cannot be empty")]
        [StringLength(50)]
        public string email { get; set; }
    }
}
