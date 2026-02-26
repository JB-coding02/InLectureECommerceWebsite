using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

public class ProductController : Controller
{
    private readonly ProductDbContext _context;

    public ProductController(ProductDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product p)
    {
        if (ModelState.IsValid)
        {
            // Add to database.
            _context.Products.Add(p);           // Add the product to the context.
            await _context.SaveChangesAsync(); // Save changes to the database.

            return RedirectToAction(nameof(Index));
        }
        return View(p); // If model state is invalid, return the view with the product data and validation errors.
    }
}