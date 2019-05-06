using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Data
{
    public interface ITag
    {
        IEnumerable<Tag> getAll();
        IEnumerable<Tag> getTagsbyProject(Project project);

        Task Create(Tag tag);
    }
}
