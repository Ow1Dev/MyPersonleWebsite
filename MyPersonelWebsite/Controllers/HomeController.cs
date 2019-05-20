using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPersonelWebsite.Data;
using MyPersonelWebsite.Models;
using MyPersonelWebsite.Models.Contakt;

namespace MyPersonelWebsite.Controllers
{
    public class HomeController : Controller
    {
        public readonly IContakt _contaktService;

        public HomeController(IContakt contaktService)
        {
            _contaktService = contaktService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ContactSendt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContact(SendViewModel.Input Input)
        {
            if(ModelState.IsValid)
            {
                await _contaktService.Send(Input.Email, Input.Content.Replace("\r\n", "</br>").ToString());
                return RedirectToAction("ContactSendt");
            }

            return RedirectToAction("Contact");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
