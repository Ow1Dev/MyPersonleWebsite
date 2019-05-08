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

        Tag getById(int id);

        Task Create(Tag tag);
        Task UpdateName(int id, string name);
        Task Delete(int id);
    }
}
