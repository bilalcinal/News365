using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;

namespace News365.UI.Areas.Controllers;
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
    public IActionResult Create(int? CategoryId)
    {
        ViewData["CategoryId"] = CategoryId;
        return View();
    }

   
}
