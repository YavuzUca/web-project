using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAAST_web.Models
{
    /// <summary>
    /// editor class
    /// </summary>
    public class Editor
    {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string fullName { get; set; }
    }
}