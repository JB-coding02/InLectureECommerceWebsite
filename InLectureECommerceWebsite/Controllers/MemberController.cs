using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

public class MemberController : Controller
{
    private readonly ProductDbContext _context;

    public MemberController(ProductDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationViewModel reg)
    {
        if (ModelState.IsValid)
        {
            // Map ViewModel to Member model tracked by DB
            Member newMember = new()
            {
                Username = reg.Username,
                Email = reg.Email,
                password = reg.Password,
                DateOfBirth = reg.DateOfBirth,
            };

            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        return View(reg);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            Member? loggedInMember = await _context.Members
                                .Where(m => (m.Username == login.UsernameOrEmail || m.Email == login.UsernameOrEmail)
                                    && m.password == login.Password)
                                .SingleOrDefaultAsync();

            if (loggedInMember == null)
            {
                ModelState.AddModelError(string.Empty, "Your provided credentials do not match any records in our database.");
                return View(login);
            }

            // Log the user in
            HttpContext.Session.SetString("Username", loggedInMember.Username);
            HttpContext.Session.SetInt32("MemberId", loggedInMember.MemberId);

            return RedirectToAction("Index", "Home");
        }
        return View(login);
    }

    public IActionResult Logout()
    {
        // Destroy current session
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
