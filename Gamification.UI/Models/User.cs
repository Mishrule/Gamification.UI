using Microsoft.AspNetCore.Identity;

namespace Gamification.UI.Models
{
    public class User : IdentityUser
    {
        // public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        // public string UserName { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        // public DateTime DateCreated { get; set; } = DateTime.Now;
        // public string Role { get; set; } = "Customer";

    }
}
