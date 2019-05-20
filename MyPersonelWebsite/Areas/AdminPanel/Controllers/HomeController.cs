using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;
using MyPersonelWebsite.Areas.AdminPanel.Models.Project;
using MyPersonelWebsite.Areas.AdminPanel.Models.Tags;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Collections;
using MyPersonelWebsite.Areas.AdminPanel.Models.Contact;

namespace MyPersonelWebsite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private ITag _tagService;
        private IProject _ProjectService;
        private IContakt _contaktService;

        private IHostingEnvironment _environment;

        private IHttpContextAccessor _accessor;

        public static int count = 0;

        public HomeController(
            ITag tagService,
            IProject ProjectService,
            IContakt contaktService,
            IHostingEnvironment environment,
            IHttpContextAccessor accessor
            )
        {
            _tagService = tagService;
            _ProjectService = ProjectService;
            _contaktService = contaktService;
            _environment = environment;
             _accessor = accessor;
        }

        public IActionResult Index()
        {
            ViewBag.test = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return View();
        }

        #region Projects
        public IActionResult ListProjects()
        {
            var model = new ProjectViewModel
            {
                projects = _ProjectService.GetAll()
                     .Select(p => new ProjectList
                     {
                         Id = p.Id,
                         Title = p.Title,
                         Desciption = p.Desciption,
                         date = p.Create_at,
                     }).OrderBy(x => x.date).ToList()
            };

            return View(model);
        }

        public IActionResult CreateProject()
        {
            var Model = new Project_CreateViewModel
            {
                Tags = _tagService.getAll()
            };

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectList Input, string Tags, IFormFile file)
        {

            if (string.IsNullOrWhiteSpace(Input.Title) && string.IsNullOrEmpty(Input.Desciption))
            {
                return RedirectToAction("CreateProject");
            }
            Data.Models.Project project = new Data.Models.Project();

            project.Title = Input.Title;
            project.Desciption = Input.Desciption;
            if (!string.IsNullOrWhiteSpace(Tags))
            {
                string[] tags = Tags.Split(",").Skip(1).ToArray();
                foreach (string item in tags)
                {
                    var t = _tagService.getByNorTag(item.ToUpper());
                    if (t == null)
                        return RedirectToAction("CreateProject");

                    project.TagLink.Add(new ProjectTag
                    {
                        project = project,
                        tag = t
                    });
                }
            }

            await _ProjectService.Create(project);
            project.HTMLPath = Helper.HtmlManager.CreateHtml(Input.content, Input.Id.ToString(), @"\content\Projects\", _environment);
            project.ImgPath = Helper.ImageManager.UploadImage(file: file, Input.Id.ToString(), "/images/Uploaded/Projects/", _environment);
            await _ProjectService.Edit(project);

            return RedirectToAction("ListProjects");
        }

        public IActionResult EditProject(int Id)
        {
            var project = _ProjectService.GetById(Id);
            if (project == null)
                return RedirectToAction("ListProjects");

            var Model = new Project_edit
            {
                input = new Project_edit.Input
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Desciption,
                    Tags = _tagService.getTagsbyProject(project.Id).ToList(),
                    Context = Helper.HtmlManager.ReadHtml(project.HTMLPath, _environment)
                },
                Tags = _tagService.getAll()

            };

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Project_edit.Input Input, string Tags, IFormFile file)
        {

            var project = _ProjectService.GetById(Input.Id);
            if (project == null)
                return RedirectToAction("ListProjects");

            if (string.IsNullOrWhiteSpace(Input.Title) && string.IsNullOrEmpty(Input.Description))
            {
                return RedirectToAction("EditProject", new { Id = Input.Id });
            }

            project.Title = Input.Title;
            project.Desciption = Input.Description;

            await _tagService.ClearTagsOnProject(project.Id);
            if (!string.IsNullOrWhiteSpace(Tags))
            {
                string[] tags = Tags.Split(",").Skip(1).ToArray();
                foreach (string item in tags)
                {
                    var t = _tagService.getByNorTag(item.ToUpper());
                    if (t == null)
                        return RedirectToAction("CreateProject");

                    project.TagLink.Add(new ProjectTag
                    {
                        project = project,
                        tag = t
                    });
                }
            }

            //TODO make _environment to string and use _environment.WebRootPath 
            //project.HTMLPath = Helper.HtmlManager.CreateHtml(Input.Context, Input.Title, @"\content\Projects\", _environment);
            Helper.HtmlManager.WriteHtml(project.HTMLPath, Input.Context, _environment);
            if(file != null)
            {
                Helper.ImageManager.DeleteImage(project.ImgPath, _environment);
                project.ImgPath = Helper.ImageManager.UploadImage(file: file, Input.Title, "/images/Uploaded/Projects/", _environment);
            }

            await _ProjectService.Edit(project);
            return RedirectToAction("ListProjects");
        }

        public async Task<IActionResult> DeleteProject(int Id)
        {
            Data.Models.Project p = _ProjectService.GetById(Id);
            Helper.HtmlManager.DeleteHtml(p.HTMLPath, _environment);
            Helper.ImageManager.DeleteImage(p.ImgPath, _environment);

            await _ProjectService.Delete(p.Id);
            return RedirectToAction("ListProjects");
        }
        #endregion

        #region Tags
        public IActionResult Tags()
        {
            var model = new TagViewModel
            {
                tags = _tagService.getAll().Select(tag => new TagListing
                {
                    Nortag = tag.NomalizedTag,
                    name = tag.tag,
                    ProjectCount = tag.ProjectLink.Count()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TagCreate(TagListing input)
        {
            var t = new Tag
            {
                tag = input.name
            };

            await _tagService.Create(t);
            return RedirectToAction("Tags");
        }

        [HttpPost]
        public async Task<IActionResult> TagDelete(string NorTag)
        {
            await _tagService.Delete(NorTag);
            return RedirectToAction("Tags");
        }

        [HttpPost]
        public async Task<IActionResult> TagEdit(TagListing input)
        {
            await _tagService.UpdateName(input.Nortag, input.name);
            return RedirectToAction("Tags");
        }
        #endregion

        #region Contakt
        
        public IActionResult ListContakt()
        {
            var Model = new ContactViewModel
            {
                contacts = _contaktService.GetAll().Select(c => new ContactList
                {
                    Id = c.Id,
                    Email = c.Email,
                    Content = c.Content,
                    HasRead = c.HasRead,
                    Send_at = c.Post_at,
                }).OrderBy(c => c.Send_at).ToList()
            };
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contaktService.Delete(id);
            return RedirectToAction("ListContakt");
        }

        public IActionResult getMessege(int id)
        {
            if (id == null)
                return NotFound(id);

            var tags = _contaktService.Read(id);
            if(tags == null)
                return NotFound(id);


            var responce = Json(new
            {
                Email = tags.Email,
                Content = tags.Content
            });

            return Ok(responce);
        }
        #endregion
    }
}