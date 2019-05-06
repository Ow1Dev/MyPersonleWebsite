using Microsoft.EntityFrameworkCore;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Create(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public Task Delete(Project project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects
                .Include(project => project.TagLink).ThenInclude(TagLink => TagLink.tag);
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

    public class TagService : ITag
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync(); ;
        }

        public IEnumerable<Tag> getAll()
        {
            return _context.Tags.OrderBy(x => x.Id).Include(x => x.ProjectLink);
        }

        public IEnumerable<Tag> getTagsbyProject(Project project)
        {
            var tags = getAll().Where(tag => tag.ProjectLink.Where(p => p.project.Id == project.Id).Any());
            return tags;
        }
    }
}
