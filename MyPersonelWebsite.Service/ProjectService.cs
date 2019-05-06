using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Service
{
    public class ProjectService : IProject
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Project project)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Project project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects
                .Include(project => project.Tag);
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
