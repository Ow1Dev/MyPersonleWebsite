using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Tags
{
    public class TagListing
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int ProjectCount { get; set; }
    }
}
