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

        //TODO: rename it to getTagsbyProjectId
        IEnumerable<Tag> getTagsbyProject(int projectId);

        Tag getByNorTag(string tag);

        Task Create(Tag tag);
        Task ClearTagsOnProject(int Projectid);
        Task UpdateName(string tagname, string name);
        Task Delete(string tag);
    }
}
