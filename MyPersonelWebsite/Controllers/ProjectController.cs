using Microsoft.AspNetCore.Mvc;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;
using MyPersonelWebsite.Models.Projects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonelWebsite.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _ProjectService;
        private readonly ITag _TagService;


        public ProjectController (
            IProject projectService,
            ITag TagService
            )
        {
            _ProjectService = projectService;
            _TagService = TagService;
        }

        public IActionResult Index()
        {
            var projects = _ProjectService.GetAll()
                .Select(project => new ProjectListingModel {
                    Id = project.Id,
                    Name = project.Title,
                    Description = project.Desciption,
                    tags = _TagService.getTagsbyProject(project)
                });

            
            var model = new ProjectIndexModel
            {
                ProjectList = projects
            };

            return View(model);
        }

        //GET Project/test
        public IActionResult test()
        {
            Tag tag = new Tag
            {
                tag = "Csharp"
            };

            Project project = new Project
            {
                Title = "test",
                Desciption = "This is a test",
            };

            project.TagLink = new List<ProjectTag>
            {
                new ProjectTag
                {
                    project = project,
                    tag = tag
                }
            };

            Task t = _ProjectService.Create(project);
            //if(t.Status)
            

            return RedirectToAction("Index");
        }
    }
}