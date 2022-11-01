﻿using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using System.Diagnostics;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Helper _helper;
        public HomeController(ILogger<HomeController> logger,Helper helper)
        {
            _logger = logger;
            _helper = helper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var text = "asp net";
            var UpperText = _helper.Upper(text);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}