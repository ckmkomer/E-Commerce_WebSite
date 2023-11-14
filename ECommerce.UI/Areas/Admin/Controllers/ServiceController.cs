using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.ServiceDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        private IValidator<CreateServiceDto> _createValidator;
        private IValidator<UpdateServiceDto> _updateValidator;

        public ServiceController(IServiceService serviceService, IMapper mapper, IValidator<CreateServiceDto> createValidator, IValidator<UpdateServiceDto> updateValidator)
        {
            _serviceService = serviceService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
          

            var serviceValues = _mapper.Map<List<ResultServiceDto>>(_serviceService.TGetList());
            return View(serviceValues);
        }

        [HttpGet]
        public IActionResult AddService()
        {
           

            return View();
        }

        [HttpPost]
        public IActionResult AddService(CreateServiceDto createServiceDto)
        {
      

            var validator = _createValidator.Validate(createServiceDto);

            if (validator.IsValid)
            {
                var serviceValue = _mapper.Map<CreateServiceDto, Service>(createServiceDto);
                _serviceService.TAdd(serviceValue);

                return LocalRedirect("/Admin/Service/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createServiceDto);
            }
        }

        public IActionResult DeleteService(int id)
        {
            var serviceID = _serviceService.TGetByID(id);
            _serviceService.TDelete(serviceID);
            return LocalRedirect("/Admin/Service/Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
       

            var serviceValue = _mapper.Map<UpdateServiceDto>(_serviceService.TGetByID(id));
            return View(serviceValue);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
        

            var validator = _updateValidator.Validate(updateServiceDto);

            if (validator.IsValid)
            {
                var serviceValue = _mapper.Map<UpdateServiceDto, Service>(updateServiceDto);
                _serviceService.TUpdate(serviceValue);

                return LocalRedirect("/Admin/Service/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateServiceDto);
            }
        }
    }
}
