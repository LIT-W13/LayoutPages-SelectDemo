using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class SelectDemo : Controller
    {
        public IActionResult Index()
        {
            ColorsDb db = new ColorsDb();
            ColorViewModel vm = new ColorViewModel
            {
                Colors = db.GetAll()
            };
            return View(vm);
        }

        public IActionResult Submit(int colorId)
        {
            ColorsDb db = new ColorsDb();
            return View(new SelectDemoViewModel
            {
                Color = db.GetById(colorId).Name
            });
        }
    }
}
