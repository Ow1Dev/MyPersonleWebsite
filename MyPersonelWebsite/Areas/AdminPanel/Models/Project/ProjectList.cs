using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Project
{
    public class ProjectList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public int Tags { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
    }
}
