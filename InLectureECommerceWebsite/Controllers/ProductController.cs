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

    public async Task<IActionResult> Index()
    {
        List<Product> allProducts = await _context.Products.ToListAsync();
        return View(allProducts);
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

            // TempData is used to pass data and will persist over a redirect.
            TempData["Message"] = $"{p.Title} was created successfully!";

            return RedirectToAction(nameof(Index));
        }
        return View(p); // If model state is invalid, return the view with the product data and validation errors.
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Product? product = _context.Products
            .Where(p => p.ProductId == id)
            .FirstOrDefault();

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}