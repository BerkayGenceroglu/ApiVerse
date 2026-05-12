using System.ComponentModel.DataAnnotations;

namespace ApiVerse.UI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; }

        public IFormFile? ProfileImage { get; set; }


        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
