using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPersonelWebsite.Data.Models
{
    public class Tag
    {
        [Key]
        public string NomalizedTag { get; set; }
        public string tag { get; set; }
        public ICollection<ProjectTag> ProjectLink { get; set; } = new List<ProjectTag>();
    }
}
