using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonelWebsite.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string tag { get; set; }
        public IEnumerable<ProjectTag> ProjectLink { get; set; }
    }
}
