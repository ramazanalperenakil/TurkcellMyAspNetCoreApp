using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            var routers = Request.RouteValues["article"];
            return View();
        }

        public IActionResult ArticleSingle(string name, int id)
        {
            var routers = Request.RouteValues["article"];
            return View();
        }
    }
}
