using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.AboutDtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
	{
		private readonly IAboutService _aboutService; 
        private readonly IMapper _mapper;
        private readonly IValidator<ResultAboutDto> _ResultValidator;

        public AboutController(IAboutService aboutService, IMapper mapper, IValidator<ResultAboutDto> resultValidator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _ResultValidator = resultValidator;
        }

        public IActionResult Index()
		{
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetList());
            return View(values);

        }
	}
}
