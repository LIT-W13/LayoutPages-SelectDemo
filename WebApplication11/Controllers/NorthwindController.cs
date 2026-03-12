using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class NorthwindController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;TrustServerCertificate=true;";
        public IActionResult Index()
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            return View(new ProductsViewModel
            {
                Products = db.GetProducts()
            });
        }
    }
}
