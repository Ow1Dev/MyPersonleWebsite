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
                    imgPath = project.ImgPath,
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
    }
}