namespace RAAST_web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blogpost")]
    public partial class Blogpost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blogpost()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public string content { get; set; }

        [StringLength(50)]
        public string cu_date { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        [StringLength(128)]
        public string asp_user_id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
