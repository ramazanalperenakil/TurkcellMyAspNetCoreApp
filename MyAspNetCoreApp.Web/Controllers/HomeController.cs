using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModel;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Helper _helper;
        private readonly AppDbContext _Context;
        public HomeController(ILogger<HomeController> logger,Helper helper, AppDbContext context)
        {
            _logger = logger;
            _helper = helper;
            _Context = context;
        }

        public IActionResult Index()
        {
            var products = _Context.Products.OrderByDescending(x=>x.Id).Select(x=> new ProductPartialViewModel()
            { 
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,

            
            
            }).ToList();

            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        public IActionResult Privacy()
        {
            var products = _Context.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,



            }).ToList();

            ViewBag.ProductListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}