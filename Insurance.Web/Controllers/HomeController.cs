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
        private readonly IContentCategoryService _categoryService;
        private readonly IContentService _contentService;

        public HomeController(ILogger<HomeController> logger, IContentCategoryService catService, IContentService contentService)
        {
            _logger = logger;
            _categoryService = catService;
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetContentCategoryAll();
            ViewBag.Contents = _contentService.GetContentAll();

            return View();
        }

        public IActionResult AddContent(Content content)
        {
            _contentService.Add(content);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteContent(int contentId)
        {

            Content content = _contentService.GetContentById(contentId);

            if (content != null)
            {
                _contentService.Delete(content);
            }

            return RedirectToAction("Index");
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
