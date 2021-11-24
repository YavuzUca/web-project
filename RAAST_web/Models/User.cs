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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Blogposts = new HashSet<Blogpost>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string fullName { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [Required]
        public string passWord_hash { get; set; }
        
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blogpost> Blogposts { get; set; }
    }

    public enum Role
    {
        Admin,
        Editor
    }
}
