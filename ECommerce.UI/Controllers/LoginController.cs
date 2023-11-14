using ECommerce.BusinessLayer.ValidationRules.AppUser;
using ECommerce.DtoLayer.Dtos.AppUserDtos;
using ECommerce.EntityLayer.Concrete.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
       
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginAppUserDto loginAppUserDto)
        {
            LoginAppUserDtoValidator lv = new LoginAppUserDtoValidator();
            ValidationResult results = lv.Validate(loginAppUserDto);
            if (results.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginAppUserDto.UserName, loginAppUserDto.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home"); //Giriş Yapınca Yönleneceği Sayfa Değişecek
                }
                else
                {
                    return RedirectToAction("Index","Register");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
