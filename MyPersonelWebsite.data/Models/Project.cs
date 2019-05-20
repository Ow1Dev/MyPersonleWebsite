using System;
using System.Collections.Generic;

namespace MyPersonelWebsite.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string ImgPath { get; set; }
        public string HTMLPath { get; set; }
        public DateTime Create_at { get; set; } = DateTime.Now;
        public ICollection<ProjectTag> TagLink { get; set; } = new List<ProjectTag>();
    }
}