using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Models.Projects
{
    public class ProjectIndexModel
    {
        public IEnumerable<ProjectListingModel> ProjectList { get; set; }
        public IEnumerable<Skill> SkillList { get; set; }
    }
}
