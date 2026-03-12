using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Foo()
        {
            return View();
        }

    }
}
