using System.ComponentModel.DataAnnotations;

namespace StockTrack.Services.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
