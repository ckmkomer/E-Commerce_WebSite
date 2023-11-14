using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.AboutDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateAboutDto> _updateValidator;

        public AboutController(IAboutService aboutService, IMapper mapper, IValidator<UpdateAboutDto> updateValidator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutService.TGetByID(1);
            var aboutValue = _mapper.Map<UpdateAboutDto>(about);
            return View(aboutValue);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var validator = _updateValidator.Validate(updateAboutDto);
            if (validator.IsValid)
            {
                var AboutValue = _mapper.Map<UpdateAboutDto, About>(updateAboutDto);

                _aboutService.TUpdate(AboutValue);

                return View();
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateAboutDto);
            }
        }
    }
}
