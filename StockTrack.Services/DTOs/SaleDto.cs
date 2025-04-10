using System.ComponentModel.DataAnnotations;

namespace StockTrack.Services.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int QuantitySold { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }

        public ProductDto Product { get; set; }

        public UserDto User { get; set; }
    }
}
