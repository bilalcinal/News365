using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Entities.Concrete;
using News365.UI.Areas.Cms.Models;

namespace News365.UI.Areas.Cms.Controllers;

[Area("Cms")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
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
      
      return RedirectToAction("Index", "Category");

     }

    

}