using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.UI.Models;

namespace News365.UI.Controllers;

public class NewsController : Controller
{
    private readonly ILogger<NewsController> _logger;
    private readonly INewsService _newsService;
    private readonly IPageService _pageService;

    public NewsController(ILogger<NewsController> logger, 
                            INewsService newsService,
                            IPageService pageService)
    {
        _logger = logger;
        _pageService = pageService;
        _newsService = newsService;
    }

    [Route("/news/{categoryName}-{categoryId}")]
    public async Task<IActionResult> Index(string categoryName = "", int categoryId = 0)
    {
        if(categoryId > 0 && !String.IsNullOrEmpty(categoryName))
        {
            
            var news = (await _newsService.GetNewsListAsync()).Data;
            
            NewsPageVM pageVM = new NewsPageVM()
            {
                Category = news.FirstOrDefault().Category,
                News = news.Where(x => x.CategoryId == categoryId == true).ToList()
            };
            return View(pageVM);
        }
        return NotFound();
    }

    [Route("/news/{slugurl}-{newsid}")]
    public async Task<IActionResult> Item(string slugurl, Guid newsid)
    {
        // if(newsid.ToString() > 0)
        // {
            var news = (await _newsService.GetByNewsModelIdAsync(newsid)).Data;
            
            return View(news);
        // }
        // return NotFound();
    }

}
