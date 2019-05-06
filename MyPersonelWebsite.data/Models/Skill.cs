using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonelWebsite.data.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short score { get; set; } = 1;
    }
}
