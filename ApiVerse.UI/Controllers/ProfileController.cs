using ApiVerse.UI.Entities;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiVerse.UI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ProfilePage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var model = new ProfileViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                PhotoPath = user.ProfileImagePath
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model, IFormFile? PhotoFile)
        {
            if (!ModelState.IsValid) return View("ProfilePage", model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            // 1. Fotoğraf Yükleme İşlemi
            if (PhotoFile != null && PhotoFile.Length > 0)
            {
                // Dosya uzantısını kontrol et ve benzersiz bir isim oluştur
                var extension = Path.GetExtension(PhotoFile.FileName);
                var newImageName = Guid.NewGuid() + extension;

                // Kaydedilecek konumu belirle (wwwroot/images/)
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);

                // Dosyayı fiziksel olarak kaydet
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await PhotoFile.CopyToAsync(stream);
                }

                // Kullanıcının veritabanındaki fotoğraf yolunu güncelle
                user.ProfileImagePath = "wwwroot/images/" + newImageName;
            }

            // 2. Diğer Bilgilerin Güncellenmesi
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            // Eğer şifre alanı doluysa şifreyi de güncelleyebilirsin (Opsiyonel)
            if (!string.IsNullOrEmpty(model.Password))
            {
                var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, passwordToken, model.Password);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Başarı Mesajı
                TempData["Type"] = "success";
                TempData["Message"] = "Profil bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("ProfilePage");
            }

            // Hata Mesajı
            TempData["Type"] = "error";
            TempData["Message"] = "Güncelleme sırasında bir hata oluştu: " + result.Errors.FirstOrDefault()?.Description;

            return View("ProfilePage", model);
        }
    }
}
