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

        public IActionResult Employees()
        {
            var db = new NorthwindDb(_connectionString);
            var vm = new EmployeesViewModel
            {
                Employees = db.GetAll()
            };
            return View(vm);
        }
    }

    //Create a .Net Core MVC Application. Get rid of the Privacy page. On the home
    //page, display a list of orders from the northwind database.
}
