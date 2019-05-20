using System.Collections.Generic;
using MyPersonelWebsite.Data.Models;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Project
{
    public class ProjectViewModel
    {
        public IEnumerable<ProjectList> projects { get; set; }
    }

    public class Project_CreateViewModel
    {
        public ProjectList Input;
        public IEnumerable<Tag> Tags;
    }

    public class Project_edit
    {
        public Input input { get; set; }
        public IEnumerable<Tag> Tags;

        public class Input
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public ICollection<Tag> Tags { get; set; }
            public string Context { get; set; }
        }
    }
}
