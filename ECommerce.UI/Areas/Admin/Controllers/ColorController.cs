using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ColorDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        private IValidator<CreateColorDto> _createValidator;
        private IValidator<UpdateColorDto> _updateValidator;

        public ColorController(IColorService colorService, IMapper mapper, IValidator<CreateColorDto> createValidator, IValidator<UpdateColorDto> updateValidator)
        {
            _colorService = colorService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<ResultColorDto>>(_colorService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddColor(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(CreateColorDto createColorDto)
        {
            var validator = _createValidator.Validate(createColorDto);
            if (validator.IsValid)
            {
                var value = _mapper.Map<CreateColorDto, Calor>(createColorDto);
               _colorService.TAdd(value);
                return LocalRedirect("/Admin/Color/Index");
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

        public IActionResult DeleteColor(int id)
        {
            var values = _colorService.TGetByID(id);
           _colorService.TDelete(values);
            
            return LocalRedirect("/Admin/Color/Index");
        }

        [HttpGet]
        public IActionResult UpdateColor(int id)
        {
            var values = _mapper.Map<UpdateColorDto>(_colorService.TGetByID(id));

            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateColor(UpdateColorDto updateColorDto)
        {
            var validator = _updateValidator.Validate(updateColorDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateColorDto, Calor>(updateColorDto);
                _colorService.TUpdate(values);
                return LocalRedirect("/Admin/Color/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateColorDto);
            }
        }

    }
}
