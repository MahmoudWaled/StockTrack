using System.ComponentModel.DataAnnotations;

namespace StockTrack.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        [MinLength(3, ErrorMessage = "min length is 3 characters")]

        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be be at least 0$")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stock Quantity is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Stock Quantity must be more than 0")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [MinLength(3, ErrorMessage = "min length is 3 characters")]

        public string Category { get; set; } = string.Empty;
    }
}
