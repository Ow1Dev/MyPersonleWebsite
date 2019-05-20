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

        public async Task Delete(int id)
        {
            _context.Projects.Remove(GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Project> GetAll()
        {
            var pro = _context.Projects
                .Include(project => project.TagLink).ThenInclude(TagLink => TagLink.tag);

            return pro;
        }

        public Project GetById(int id)
        {
            return _context.Projects.Where(project => project.Id == id).FirstOrDefault();
        }

        public Project GetbyTitle(string title)
        {
            title = string.IsNullOrEmpty(title) ? "" : title;
            return _context.Projects.Where(project => project.Title.ToLower() == title.ToLower()).SingleOrDefault();
        }
    }

    public class TagService : ITag
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ClearTagsOnProject(int Projectid)
        {
            var Tags = getTagsbyProject(Projectid);
            foreach (var item in Tags)
            {
                item.ProjectLink.Remove(item.ProjectLink.Where(pl => pl.ProjectId == Projectid).FirstOrDefault());
            }
            _context.SaveChanges();
        }

        public async Task Create(Tag tag)
        {
            if(!String.IsNullOrEmpty(tag.tag))
            {
                tag.NomalizedTag = tag.tag.ToUpper();
                _context.Tags.Add(tag);
                await _context.SaveChangesAsync(); ;
            }
        }

        public async Task Delete(string tag)
        {
            _context.Tags.Remove(getByNorTag(tag.ToUpper()));
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Tag> getAll()
        {
            return _context.Tags
                .Include(x => x.ProjectLink);
        }

        public Tag getByNorTag(string Nortag)
        {
            return _context.Tags.Single(Tag => Tag.NomalizedTag == Nortag);
        }

        public IEnumerable<Tag> getTagsbyProject(int projectId)
        {
            try
            {
                var tags = getAll().Where(tag => tag.ProjectLink.Where(p => p.ProjectId == projectId).Any());
                return tags;
            }
            catch 
            {
                return null;
            }
        }

        public async Task UpdateName(string tagname, string name)
        {
            var tag = getByNorTag(tagname.ToUpper());
            tag.tag = name;
            tag.NomalizedTag = name.ToUpper();
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }
    }
}
