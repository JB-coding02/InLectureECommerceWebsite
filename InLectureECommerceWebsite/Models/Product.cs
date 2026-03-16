using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

/// <summary>
/// Represents an individual product for sale.
/// </summary>
public class Product
{
    /// <summary>
    /// The unique identifier for the product.
    /// </summary>
    [Key]
    public int ProductId { get; set; }

    /// <summary>
    /// The user facing title of the product.
    /// </summary>
    [StringLength(50, ErrorMessage = "Titles cannot be more than 50 characters")]
    // [Display(Name = "Product Name")]
    public required string Title { get; set; }

    /// <summary>
    /// The current sales price of the product.
    /// </summary>
    [Range(0, 10_000)]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}

public class ProductListViewModel
{
    public required IEnumerable<Product> Products { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int ProductsPerPage { get; set; }
    public int TotalItems { get; set; }

    // Optional search and filtering criteria used to build the product list.
    public string? ProductTitleSearch { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}