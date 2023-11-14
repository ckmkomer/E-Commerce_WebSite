using ECommerce.BusinessLayer.Abstract;
using ECommerce.BusinessLayer.ValidationRules.AppUser;
using ECommerce.DtoLayer.Dtos.AppUserDtos;
using ECommerce.EntityLayer.Concrete.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    [AllowAnonymous]
    
    public class RegisterController : Controller
    {
        private readonly   ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(ICartService cartService, UserManager<AppUser> userManager )
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterAppUserDto registerAppUserDto)
        {
            RegisterAppUserDtoValidator rv = new RegisterAppUserDtoValidator();
            ValidationResult results = rv.Validate(registerAppUserDto);
            if (results.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = registerAppUserDto.Name,
                    Surname = registerAppUserDto.Surname,
                    Email = registerAppUserDto.Email,
                    UserName = registerAppUserDto.UserName
                };

                if (registerAppUserDto.Password == registerAppUserDto.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, registerAppUserDto.Password);

                    if (result.Succeeded)
                    {
                       
                        
                        var user = await _userManager.FindByNameAsync(registerAppUserDto.UserName);
                        if (user != null) 
                        {
                            _cartService.InitializeCart(user.Id);
                        }
                        await _userManager.AddToRoleAsync(user, "Admin");
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View(registerAppUserDto);

        }

        
    }
}
