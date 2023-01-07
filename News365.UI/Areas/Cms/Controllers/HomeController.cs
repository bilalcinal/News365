using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News365.UI.Areas.Cms.Controllers;
[Area("Cms")]
[Authorize(Roles = "Admin")]

public class HomeController : Controller
{
    [Route("/cms/")]
    public IActionResult Index()
    {
        return View();
    }
}
