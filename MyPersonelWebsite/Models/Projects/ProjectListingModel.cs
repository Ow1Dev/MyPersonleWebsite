using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Models.Projects
{
    public class ProjectListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Tag> tags { get; set; }
    }
}
