using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonelWebsite.Areas.AdminPanel.Controllers
{
    [Authorize]
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }
    }
}