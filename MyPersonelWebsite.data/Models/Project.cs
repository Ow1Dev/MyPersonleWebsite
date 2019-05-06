using System.Collections.Generic;

namespace MyPersonelWebsite.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public IEnumerable<ProjectTag> TagLink  { get; set; }
    }
}