using System.ComponentModel.DataAnnotations;

namespace StockTrack.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Category { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
