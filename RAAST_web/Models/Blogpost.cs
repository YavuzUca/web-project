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
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int? user_id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string content { get; set; }

        [StringLength(50)]
        public string cu_date { get; set; }

        [StringLength(50)]
        public string slug { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual User User { get; set; }
    }
}
