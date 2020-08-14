using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Insurance.Web.Models;
using Insurance.Service.RenterContent;
using Insurance.Data.Models;

namespace Insurance.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentCategoryService _categoryService;
        private readonly IContentService _contentService;

        public HomeController(IContentCategoryService catService, IContentService contentService)
        {
            _categoryService = catService;
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetContentCategoryAll();
            var contents = _contentService.GetContentAll();

            ViewBag.Categories = categories
                .Select(a => new ContentCategoryListModel
                {
                    Id = a.Id,
                    CategoryName = a.CategoryName,
                    Contents = contents.Where(w=>w.ContentCategoryId==a.Id).OrderBy(o => o.ContentName),
                    ContentTotal = contents.Where(w=>w.ContentCategoryId == a.Id).Sum(s=>s.Value)
                }).OrderBy(o=>o.CategoryName).ToList();

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
