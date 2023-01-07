using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Entities.Concrete;
using News365.UI.Areas.Cms.Models;

namespace News365.UI.Areas.Cms.Controllers;

[Area("Cms")]
[Authorize(Roles = "Admin")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _categoryService.GetCategoryListAsync();
        if (list.Success)
        {
            return View(list.Data);
        }
        return NotFound();
    }

    public IActionResult Create(int CategoryId)
    {
        ViewData["CategoryId"] = CategoryId;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryVM categoryVM)
    {
        if (!ModelState.IsValid)
        {
            return View(categoryVM);
        }
        var category = new Category

        {

            Name = categoryVM.Category.Name,
            SlugUrl = categoryVM.Category.SlugUrl
        };

        var Category = await _categoryService.AddAsync(category);

        return RedirectToAction("Index", "Categories");

    }

    public async Task<IActionResult> Edit(Guid Id)
    {
        var result = await _categoryService.GetByCategoryIdAsync(Id);
        var Category = result.Data;
        return View(new CategoryVM()
        {
            Category = Category
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryVM categoryVM)
    {
      if(categoryVM.Category.Id != null)
      {
        try
        {
            categoryVM.Category.SlugUrl = UrlSeoHelper.UrlSeo(categoryVM.Category.SlugUrl);
            categoryVM.Category.Name = (categoryVM.Category.Name);
            var categoryUpdate = await _categoryService.UpdateAsync(categoryVM.Category);
            if (categoryUpdate.Success)
            TempData["Success"] = categoryUpdate.Message;

        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return RedirectToAction("Index", "Categories");

      }
       return NotFound();
        
    }
    public async Task<IActionResult> Delete(Guid Id)
    {
        var result = await _categoryService.GetByCategoryIdAsync(Id);
        var Category = result.Data;
        await _categoryService.RemoveAsync(Category);
        
        TempData["Success"] = Messages.DeleteMessage;
        return RedirectToAction("Index", "Categories");
    }


}




