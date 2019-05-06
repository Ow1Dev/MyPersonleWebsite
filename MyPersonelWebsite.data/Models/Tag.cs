using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonelWebsite.data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string tag { get; set; }
        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
