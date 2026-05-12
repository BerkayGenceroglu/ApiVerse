namespace ApiVerse.UI.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }

        public string? Password { get; set; }
        public string? PasswordAgain { get; set; }
    }
}
