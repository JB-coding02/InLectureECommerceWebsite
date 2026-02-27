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

    [HttpPost, ValidateAntiForgeryToken]
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
    public async Task<IActionResult> Edit(int id)
    {
        // If user tried to go to the delete page without navigating on
        // our website
        if (id <= 0)
        {
            return BadRequest();
        }

        Product? product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Update(product); // Update the product in the context.
            await _context.SaveChangesAsync(); // Save changes to the database.

            // TempData is used to pass data and will persist over a redirect.
            TempData["Message"] = $"{product.Title} was updated successfully!";

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        // If user tried to go to the delete page without navigating on
        // our website
        if (id <= 0)
        {
            return BadRequest();
        }

        Product? product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost, ActionName(nameof(Delete)), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Product? product = await _context.Products.FindAsync(id);

        if (product == null) 
        {
            return RedirectToAction(nameof(Index));
        }

        _context.Remove(product);
        await _context.SaveChangesAsync();

        TempData["Message"] = $"{product.Title} was deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}