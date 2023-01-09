using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.Entities.Concrete;
using News365.UI.Areas.Cms.Models;

namespace News365.UI.Areas.Cms.Controllers;

[Area("Cms")]
[Authorize(Roles = "Admin")]
public class PagesController : Controller
{
    private readonly IPageService _pageService;
    private readonly IDocumentService _documentService;
    public PagesController(IPageService pageService, IDocumentService documentService)
    {
        _pageService = pageService;
        _documentService = documentService;
    }

    public async Task<IActionResult> Index()
    {
        return View((await _pageService.GetPageListAsync()).Data.ToList());
    }

     public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PageVM pageVM, IFormFile fileLeft, IFormFile fileCenter, IFormFile fileRight)
    {
        try
        {
            var FileCodeLeft = await _documentService.AddUploadAsync(fileLeft, "/file/page/");
            var FileCodeCenter = await _documentService.AddUploadAsync(fileCenter, "/file/page/");
            var FileCodeRight = await _documentService.AddUploadAsync(fileRight, "/file/page/");
            if (!FileCodeLeft.Success && !FileCodeCenter.Success && !FileCodeRight.Success)
            {
                TempData["Warning"] = "Fotoğraf yüklenirken bir hata oluştu!";
                return View(pageVM);
            }
            else
            {
                var result = await _pageService.AddAsync(new Page()
                {
                    Title = pageVM.Page.Title,
                    Description = pageVM.Page.Description,
                    FileCodeCenterLeft = FileCodeLeft.Data,
                    FileCodeCenter = FileCodeCenter.Data,
                    FileCodeCenterRight = FileCodeRight.Data,
                    SlugUrl = UrlSeoHelper.UrlSeo(pageVM.Page.SlugUrl)
                });
                if (result.Success)
                {
                    
                    TempData["Success"] = result.Message;
                }
                return RedirectToAction(nameof(SlidersController.Index));
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return View(pageVM);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PageVM pageVM, IFormFile fileLeft, IFormFile fileCenter, IFormFile fileRight)
    {
        try
        {
            if (fileLeft != null)
            {
                if (pageVM.Page.FileCodeCenterLeft != null || pageVM.Page.FileCodeCenterLeft != string.Empty)
                {
                    IDataResult<string> FileCode = await _documentService.UpdateUploadAsync(fileLeft, pageVM.Page.FileCodeCenterLeft, "/file/page/");
                    pageVM.Page.FileCodeCenterLeft = FileCode.Data;
                    if (!FileCode.Success)
                    {
                        TempData["Warning"] = FileCode.Message;
                        return View(pageVM);
                    }
                }
            }
            if (fileCenter != null)
            {
                if (pageVM.Page.FileCodeCenter != null || pageVM.Page.FileCodeCenter != string.Empty)
                {
                    IDataResult<string> FileCode = await _documentService.UpdateUploadAsync(fileCenter, pageVM.Page.FileCodeCenter, "/file/page/");
                    pageVM.Page.FileCodeCenter = FileCode.Data;
                    if (!FileCode.Success)
                    {
                        TempData["Warning"] = FileCode.Message;
                        return View(pageVM);
                    }
                }
            }
            if (fileRight != null)
            {
                if (pageVM.Page.FileCodeCenterRight != null || pageVM.Page.FileCodeCenterRight != string.Empty)
                {
                    IDataResult<string> FileCode = await _documentService.UpdateUploadAsync(fileRight, pageVM.Page.FileCodeCenterRight, "/file/page/");
                    pageVM.Page.FileCodeCenterRight = FileCode.Data;
                    if (!FileCode.Success)
                    {
                        TempData["Warning"] = FileCode.Message;
                        return View(pageVM);
                    }
                }
            }
            pageVM.Page.SlugUrl = UrlSeoHelper.UrlSeo(pageVM.Page.SlugUrl);
            var receiptUpdate = await _pageService.UpdateAsync(pageVM.Page);
            TempData["Success"] = receiptUpdate.Message;
            return RedirectToAction(nameof(PagesController.Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return View(pageVM);
    }
    public async Task<IActionResult> Edit(Guid Id)
    {
        if (Id != null)
        {
            var pageRow = await _pageService.GetByPageIdAsync(Id);
            if (pageRow.Success)
            {
                return View(new PageVM()
                {
                    Page = pageRow.Data
                });
               
            }
        }
        return NotFound();
    }

     public async Task<IActionResult> Delete(Guid Id)
    {
       var result = await _pageService.GetByPageIdAsync(Id);
        var page = result.Data;
        await _pageService.RemoveAsync(page);
        
        TempData["Success"] = Messages.DeleteMessage;
        return RedirectToAction("Index", "Pages");
    }
}