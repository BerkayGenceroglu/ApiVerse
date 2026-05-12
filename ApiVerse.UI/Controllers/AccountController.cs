using ApiVerse.UI.Entities;
using ApiVerse.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiVerse.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(model);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError(string.Empty, "Hesabınız aktif değil.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                user.LastLoginAt = DateTime.Now;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("MovieList", "MovieUI");
            }

            ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new AppUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Email,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            if (model.ProfileImage != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ProfileImage.FileName)}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/users", fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await model.ProfileImage.CopyToAsync(stream);
                user.ProfileImagePath = $"/images/users/{fileName}";
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                TempData["Success"] = "Kayıt başarılı! Giriş yapabilirsiniz.";
                return RedirectToAction("Register");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }
    }
}
