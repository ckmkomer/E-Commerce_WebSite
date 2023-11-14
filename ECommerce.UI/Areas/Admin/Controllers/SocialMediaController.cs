using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.SocialMediaDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private IValidator<CreateSocialMediaDto> _createValidator;
        private IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper, IValidator<CreateSocialMediaDto> createValidator, IValidator<UpdateSocialMediaDto> updateValidator)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            var socialMediaValues = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetList());
            return View(socialMediaValues);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var validator = _createValidator.Validate(createSocialMediaDto);

            if (validator.IsValid)
            {
                var socialMediaValue = _mapper.Map<CreateSocialMediaDto, SocialMedia>(createSocialMediaDto);
               _socialMediaService.TAdd(socialMediaValue);

                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createSocialMediaDto);
            }
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMediaID = _socialMediaService.TGetByID(id);
           _socialMediaService.TDelete(socialMediaID);
            return LocalRedirect("/Admin/SocialMedia/Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMediaValue = _mapper.Map<UpdateSocialMediaDto>(_socialMediaService.TGetByID(id));
            return View(socialMediaValue);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var validator = _updateValidator.Validate(updateSocialMediaDto);

            if (validator.IsValid)
            {
                var socialMediaValue = _mapper.Map<UpdateSocialMediaDto, SocialMedia>(updateSocialMediaDto);
               _socialMediaService.TUpdate(socialMediaValue);
                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateSocialMediaDto);
            }
        }
    }
}
