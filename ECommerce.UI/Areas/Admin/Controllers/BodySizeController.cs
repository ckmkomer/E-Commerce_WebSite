using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.BodySizeDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodySizeController : Controller
    {
         private readonly IBodySizeService _bodySizeService;

        private readonly IMapper _mapper;
        private IValidator<CreateBodySizeDto> _createValidator;
        private IValidator<UpdateBodySizeDto> _updateValidator;

        public BodySizeController(IBodySizeService bodySizeService, IMapper mapper, IValidator<CreateBodySizeDto> createValidator, IValidator<UpdateBodySizeDto> updateValidator)
        {
            _bodySizeService = bodySizeService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            // AutoMapper kullanarak Entity sınıflarını Dto'ya dönüştürüp, UI katmanına gönderir.
            var bodySizeValues = _mapper.Map<List<ResultBodySizeDto>>(_bodySizeService.TGetList());
            return View(bodySizeValues);
        }


        [HttpGet]
        public IActionResult AddBodySize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBodySize(CreateBodySizeDto createBodySizeDto)
        {
            // FluentValidation ile gelen veriyi doğrular.
            var validator = _createValidator.Validate(createBodySizeDto);
            if (validator.IsValid)
            {
                // AutoMapper kullanarak Dto'yu Entity'ye dönüştürür ve veritabanına ekler.
                var bodySizeValue = _mapper.Map<CreateBodySizeDto, BodySize>(createBodySizeDto);
                _bodySizeService.TAdd(bodySizeValue);
              
                return LocalRedirect("/Admin/BodySize/Index");
            }
            else
            {
                // Hata mesajlarını ModelState'e ekler ve hata durumunda aynı sayfayı tekrar gösterir.
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createBodySizeDto);
            }
        }


        public IActionResult DeleteBodySize(int id)
        {
            var bodySizeID = _bodySizeService.TGetByID(id);
            _bodySizeService.TDelete(bodySizeID);
            return LocalRedirect("/Admin/BodySize/Index");
        }


        [HttpGet]
        public IActionResult UpdateBodySize(int id)
        {

            var bodySizeValue = _mapper.Map<UpdateBodySizeDto>(_bodySizeService.TGetByID(id));
            return View(bodySizeValue);
        }

        [HttpPost]
        public IActionResult UpdateBodySize(UpdateBodySizeDto updateBodySizeDto)
        {
            // FluentValidation ile gelen veriyi doğrular.
            var validator = _updateValidator.Validate(updateBodySizeDto);
            if (validator.IsValid)
            {
                // AutoMapper kullanarak Dto'yu Entity'ye dönüştürür ve veritabanında günceller.
                var BodySizeValue = _mapper.Map<UpdateBodySizeDto, BodySize>(updateBodySizeDto);
                _bodySizeService.TUpdate(BodySizeValue);

                return LocalRedirect("/Admin/BodySize/Index");
            }
            else
            {
                // Hata mesajlarını ModelState'e ekler ve hata durumunda aynı sayfayı tekrar gösterir.
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateBodySizeDto);
            }
        }
    }
}
