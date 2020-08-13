using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Insurance.Web.Models;
using Insurance.Service.RenterContent;
using Insurance.Data.Models;

namespace Insurance.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentCategoryService _catService;

        public HomeController(ILogger<HomeController> logger, IContentCategoryService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        public IActionResult Index()
        {
            //ContentCategory category = new ContentCategory()
            //{
            //    Id = 1,
            //    CategoryName = "Electronics"
            //};
            //_catService.Add(category);

            //Content content = new Content()
            //{
            //    Id = 1,
            //    ContentCategoryId = 1,
            //    ContentName = "TV",
            //    Value = 2000
            //};
            //_catService.AddContent(content);

            var cats = _catService.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
