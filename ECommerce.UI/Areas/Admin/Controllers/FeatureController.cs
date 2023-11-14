using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.FeatureDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        private IValidator<CreateFeatureDto> _createValidator;
        private IValidator<UpdateFeatureDto> _updateValidator;

        public FeatureController(IFeatureService featureService, IMapper mapper, IValidator<CreateFeatureDto> createValidator, IValidator<UpdateFeatureDto> updateValidator)
        {
            _featureService = featureService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddFeature(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto createColorDto)
        {
            var validator = _createValidator.Validate(createColorDto);
            if (validator.IsValid)
            {
                var value = _mapper.Map<CreateFeatureDto, Feature>(createColorDto);
                _featureService.TAdd(value);
                return LocalRedirect("/Admin/Feature/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createColorDto);
            }

        }

        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            _featureService.TDelete(values);
            return LocalRedirect("/Admin/Feature/Index");
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values = _mapper.Map<UpdateFeatureDto>(_featureService.TGetByID(id));

            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var validator = _updateValidator.Validate(updateFeatureDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateFeatureDto, Feature>(updateFeatureDto);
               _featureService.TUpdate(values);

                return LocalRedirect("/Admin/Feature/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateFeatureDto);
            }
        }

    }
}

