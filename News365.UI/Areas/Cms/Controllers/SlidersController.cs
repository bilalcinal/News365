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
public class SlidersController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly IDocumentService _documentService;
    public SlidersController(ISliderService sliderService, IDocumentService documentService)
    {
        _sliderService = sliderService;
        _documentService = documentService;
    }
    public async Task<IActionResult> Index()
    {
        return View((await _sliderService.GetSliderListAsync()).Data.ToList());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SliderVM sliderVM, IFormFile file)
    {
        try
        {
            var FileCode = await _documentService.AddUploadAsync(file, "/file/slider/");
            if (!FileCode.Success)
            {
                TempData["Warning"] = FileCode.Message;
                return View(sliderVM);
            }
            else
            {
                var result = await _sliderService.AddAsync(new Slider()
                {
                    Title = sliderVM.Slider.Title,
                    Description = sliderVM.Slider.Description,
                    FileCode = FileCode.Data,
                    SlugUrl = UrlSeoHelper.UrlSeo(sliderVM.Slider.SlugUrl)
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
        return View(sliderVM);
    }
    public async Task<IActionResult> Edit(Guid Id)
    {
        if (Id != null)
        {
            var sliderRow = await _sliderService.GetBySliderIdAsync(Id);
            if (sliderRow.Success)
            {
                return View(new SliderVM()
                {
                    Slider = sliderRow.Data,
                    
                });
            }
        }
        return NotFound();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SliderVM sliderVM, IFormFile file)
    {
        try
        {
            if (file != null)
            {
                if (sliderVM.Slider.FileCode != null || sliderVM.Slider.FileCode != string.Empty)
                {
                    IDataResult<string> FileCode = await _documentService.UpdateUploadAsync(file, sliderVM.Slider.FileCode, "/file/slider/");
                    sliderVM.Slider.FileCode = FileCode.Data;
                    if (!FileCode.Success)
                    {
                        TempData["Warning"] = FileCode.Message;
                        return View(sliderVM);
                    }
                }
            }
            sliderVM.Slider.SlugUrl = UrlSeoHelper.UrlSeo(sliderVM.Slider.SlugUrl);
            var receiptUpdate = await _sliderService.UpdateAsync(sliderVM.Slider);
            if (receiptUpdate.Success)
            TempData["Success"] = receiptUpdate.Message;
            return RedirectToAction(nameof(SlidersController.Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Beklenmedik Hata: {ex.Message}";
        }
        return View(sliderVM);
    }
    public async Task<IActionResult> Delete(Guid Id)
    {
       var result = await _sliderService.GetBySliderIdAsync(Id);
        var slider = result.Data;
        await _sliderService.RemoveAsync(slider);
        
        TempData["Success"] = Messages.DeleteMessage;
        return RedirectToAction("Index", "Sliders");
    }
}
