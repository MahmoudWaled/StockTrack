using System.ComponentModel.DataAnnotations;

namespace StockTrack.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "UserName must be between 3 and 100 characters")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Role is required")]
        [RegularExpression("^(Admin|User|Seller)$", ErrorMessage = "Role must be either 'Admin' or 'User' or 'Seller'")]
        public string Role { get; set; } = string.Empty;
    }
}
