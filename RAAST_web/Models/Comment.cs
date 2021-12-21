namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public int? blogpost_id { get; set; }

        [StringLength(50)]
        public string commenter { get; set; }

        [StringLength(250)]
        public string content { get; set; }

        [StringLength(50)]
        public string cu_date { get; set; }

        public virtual Blogpost Blogpost { get; set; }
    }
}
