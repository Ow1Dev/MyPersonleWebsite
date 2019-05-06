﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyPersonelWebsite.Data.Models
{
    public class ProjectTag
    {
        public int ProjectId { get; set; }
        public int TagId { get; set; }

        public Project project { get; set; }
        public Tag tag { get; set; }
    }
}
