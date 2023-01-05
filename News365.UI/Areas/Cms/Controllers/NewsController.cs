using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Entities.Concrete;
using News365.UI.Areas.Cms.Models;

namespace News365.UI.Areas.Cms.Controllers;

[Area("Cms")]
// [Authorize(Roles = "Admin")]
public class NewsController : Controller
{
    private readonly INewsService _newsService;
    private readonly ICategoryService _categoryService;
    private readonly IDocumentService _documentService;
    public NewsController(INewsService newsService, ICategoryService categoryService , IDocumentService documentService)
    {
        _newsService = newsService;
        _categoryService = categoryService;
        _documentService = documentService;
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
    public async Task<IActionResult> Create(NewsVM newsVM, IFormFile file)
    {
        try
        {
            var FileCode = await _documentService.AddUploadAsync(file, "/file/product/");
            if (!FileCode.Success)
            {
                TempData["Warning"] = FileCode.Message;
                return View(newsVM);
            }
            else
            {
                var product = await _newsService.AddAsync(new NewsModel()
                {
                    Title = newsVM.NewsModel.Title,
                    Body = newsVM.NewsModel.Body,
                    FileCode = FileCode.Data,
                    CategoryId = newsVM.NewsModel.CategoryId,
                    SlugUrl = UrlSeoHelper.UrlSeo(newsVM.NewsModel.SlugUrl),
                    
                });
                
                    TempData["Success"] = product.Message;
                
                return RedirectToAction(nameof(NewsController.Index));
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return View(newsVM);
    }
    public async Task<IActionResult> Edit(Guid Id)
    {
        var result = await _newsService.GetByNewsModelIdAsync(Id);
        var NewsModel = result.Data;
        return View(new NewsVM()
        {
            NewsModel = NewsModel
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(NewsVM newsVM)
    {
      if(newsVM.NewsModel.Id != null)
      {
        try
        {
            newsVM.NewsModel.SlugUrl = UrlSeoHelper.UrlSeo(newsVM.NewsModel.SlugUrl);
            newsVM.NewsModel.Title = (newsVM.NewsModel.Title);
            newsVM.NewsModel.Body = (newsVM.NewsModel.Body);
            newsVM.NewsModel.CategoryId = (newsVM.NewsModel.CategoryId);
            newsVM.NewsModel.FileCode = (newsVM.NewsModel.FileCode);
            var newsUpdate = await _newsService.UpdateAsync(newsVM.NewsModel);
            if (newsUpdate.Success)
            TempData["Success"] = newsUpdate.Message;

        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return RedirectToAction("Index", "News");

      }
       return NotFound();
        
    }
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _newsService.GetByNewsModelIdAsync(Id);
        var newsModel = result.Data;
        await _newsService.RemoveAsync(newsModel);
        
        TempData["Success"] = Messages.DeleteMessage;
        return RedirectToAction("Index", "News");
    }
}
