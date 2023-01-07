using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using News365.Business.Abstract;
using News365.Entities.Concrete;

namespace News365.UI.Areas.Cms.Controllers;
[Area("Cms")]
public class AccountController : Controller
{
    private readonly IUserService _userService;
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("/cms/account/login/")]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [Route("/cms/account/Login/")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(User user, string returnUrl = null)
    {
        var users = await _userService.SignInAsync(user);
        if (!users.Success)
        {
            TempData["Error"] = users.Message;
            return View(user);
        }
        TempData["Success"] = users.Message;
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        return RedirectToAction("Index", "Home");
    }

    [Route("/cms/account/logout/")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
