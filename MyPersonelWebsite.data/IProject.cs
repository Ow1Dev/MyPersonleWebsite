using MyPersonelWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Data
{
    public interface IProject
    {
        Project GetById(int id);
        IEnumerable<Project> GetAll();

        Task Create(Project project);
        Task Delete(Project project);
    }
}
