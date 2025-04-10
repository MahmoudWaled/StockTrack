using System.ComponentModel.DataAnnotations;

namespace StockTrack.Data.Entities
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		[StringLength(100)]
		public string UserName { get; set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
		[Required]
		public string Role { get; set; } = string.Empty;
		public ICollection<Sale> Sales { get; set; } = new List<Sale>();

	}
}
