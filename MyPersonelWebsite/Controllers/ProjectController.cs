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
        private readonly ISkill _SkillService;


        public ProjectController(
            IProject projectService,
            ITag TagService,
            ISkill SkillService
            )
        {
            _ProjectService = projectService;
            _TagService = TagService;
            _SkillService = SkillService;
        }

        public IActionResult Index()
        {
            var projects = _ProjectService.GetAll()
                .Select(project => new ProjectListingModel
                {
                    Id = project.Id,
                    Name = project.Title,
                    Description = project.Desciption,
                    tags = _TagService.getTagsbyProject(project.Id)
                }).ToList();


            var model = new ProjectIndexModel
            {
                ProjectList = projects,
                SkillList = _SkillService.GetAll().Reverse().ToList()
            };

            return View(model);
        }

        public IActionResult View(string Title)
        {
            var project = _ProjectService.GetbyTitle(Title);
            if(project != null)
            {
                var model = BuildProjectLising(_ProjectService.GetbyTitle(Title));
                return View(model);
            }

            return RedirectToAction("Index", "Project");
        }

        public static ProjectListingModel BuildProjectLising(Project project)
        {
            return new ProjectListingModel
            {
                Id = project.Id,
                Name = project.Title,
                Description = project.Desciption,
            };
        }

        //POST Project/TestCreate
        [HttpPost]
        public async Task<IActionResult> TestCreate()
        {
            Project project = new Project
            {
                Title = "secound code test",
                Desciption = "This a project that was create by code",
            };

            project.TagLink = new List<ProjectTag>
            {
                new ProjectTag
                {
                    project = project,
                    tag = _TagService.getById(10)
                },
                new ProjectTag
                {
                    project = project,
                    tag = _TagService.getById(11)
                }
            };

            await _ProjectService.Create(project);

            return RedirectToAction("Index", "Project");
        }

        //POST Project/TestDelete/{id}
        [HttpDelete]
        public async Task<IActionResult> TestDelete(int id)
        {
            await _ProjectService.Delete(id);
            return RedirectToAction("Index", "Project");
        }
    }
}