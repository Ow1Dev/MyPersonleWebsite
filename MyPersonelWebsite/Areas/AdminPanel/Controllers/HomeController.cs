using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPersonelWebsite.Areas.AdminPanel.Models.Tags;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Data.Models;

namespace MyPersonelWebsite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        ITag _tagService;

        public HomeController(ITag tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Tags()
        {
            var model = new TagViewModel
            {
                tags = _tagService.getAll().Select(tag => new TagListing
                {
                    Id = tag.Id,
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
        public async Task<IActionResult> TagDelete(int Id)
        {
            await _tagService.Delete(Id);
            return RedirectToAction("Tags");
        }

        [HttpPost]
        public async Task<IActionResult> TagEdit(TagListing input)
        {
            await _tagService.UpdateName(input.Id, input.name);
            return RedirectToAction("Tags");
        }
    }
}