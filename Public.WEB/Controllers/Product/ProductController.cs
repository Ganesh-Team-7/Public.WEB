using Microsoft.AspNetCore.Mvc;

namespace Public.WEB.Controllers.Product
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
