using Microsoft.AspNetCore.Identity;

namespace ApiVerse.UI.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
