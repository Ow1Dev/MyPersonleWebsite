using MyPersonelWebsite.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Data
{
    public interface IProject
    {
        Project GetById(int id);
        Project GetbyTitle(string title);
        IEnumerable<Project> GetAll();

        Task Create(Project project);
        Task Delete(int id);
    }
}
