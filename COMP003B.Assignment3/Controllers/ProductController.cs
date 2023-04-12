using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();
        
        //GET Products
        [HttpGet]
        public IActionResult Index()
        {
            return View(products);
        }
    }
}
