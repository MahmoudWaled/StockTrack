using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StockTrack.ViewModels
{
    public class SaleVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please select a seller.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter the quantity sold.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity sold must be at least 1.")]
        public int QuantitySold { get; set; }
        public decimal TotalPrice { get; set; }
        [Required(ErrorMessage = "Please select a sale date.")]
        public DateTime SaleDate { get; set; }
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Sellers { get; set; } = new List<SelectListItem>();
        [ValidateNever]
        public ProductVM Product { get; set; }
        [ValidateNever]
        public UserVM User { get; set; }
    }
}
