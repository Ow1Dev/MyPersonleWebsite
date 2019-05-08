using MyPersonelWebsite.Data.Models;
using System.Collections.Generic;

namespace MyPersonelWebsite.Areas.AdminPanel.Models.Tags
{
    public class TagViewModel
    {
        public IEnumerable<TagListing> tags;
        public TagListing input;
    }
}
