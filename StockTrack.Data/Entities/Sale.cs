using System.ComponentModel.DataAnnotations;

namespace StockTrack.Data.Entities
{
    public class Sale
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

        public Product Product { get; set; }

        public User User { get; set; }
    }
}
