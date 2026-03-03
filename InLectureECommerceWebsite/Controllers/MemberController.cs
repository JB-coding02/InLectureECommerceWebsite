using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class MemberController : Controller
{
    public IActionResult Register()
    {
        return View();
    }
}
