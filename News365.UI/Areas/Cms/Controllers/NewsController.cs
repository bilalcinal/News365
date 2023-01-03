using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Entities.Concrete;
using News365.UI.Areas.Cms.Models;

namespace News365.UI.Areas.Cms.Controllers;

[Area("Cms")]
// [Authorize(Roles = "Admin")]
public class NewsController : Controller
{
    private readonly INewsService _newsService;
    private readonly ICategoryService _categoryService;
    public NewsController(INewsService newsService, ICategoryService categoryService)
    {
        _newsService = newsService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        return View((await _newsService.GetNewsListAsync()).Data.ToList());
    }

    public async Task<IActionResult> Create()
    {
        return View(new NewsVM()
        {
            Categories = (await _categoryService.GetCategoryListAsync()).Data.ToList()
        });
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NewsVM newsVM)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(newsVM);
            }
            var newsModel = new NewsModel

            {
                CategoryId = newsVM.NewsModel.CategoryId,
                Title = newsVM.NewsModel.Title,
                FileCode = newsVM.NewsModel.FileCode,
                Body = newsVM.NewsModel.Body,
                SlugUrl = newsVM.NewsModel.SlugUrl
            };

            var Category = await _newsService.AddAsync(newsModel);

            return RedirectToAction(nameof(NewsController.Index));
        }
         catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return View(newsVM);


    }
}
