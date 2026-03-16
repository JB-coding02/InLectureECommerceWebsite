using System.Collections.Generic;

namespace ECommerce.Models
{
    public class ProductListViewModel
    {
        public required IEnumerable<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ProductsPerPage { get; set; }
        public int TotalItems { get; set; }
    }
}
