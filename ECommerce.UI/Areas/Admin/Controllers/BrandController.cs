using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.BrandDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBrandDto> _createValidator;
    private readonly IValidator<UpdateBrandDto> _updateValidator;

        public BrandController(IBrandService brandService, IMapper mapper, IValidator<CreateBrandDto> createValidator, IValidator<UpdateBrandDto> updateValidator)
        {
            _brandService = brandService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
    {
        var values = _mapper.Map<List<ResultBrandDto>>(_brandService.TGetList());
        return View(values);
    }

    [HttpGet]
    public IActionResult AddBrand(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBrand(CreateBrandDto createBrandDto)
    {
        var validator = _createValidator.Validate(createBrandDto);
        if (validator.IsValid)
        {
            var value = _mapper.Map<CreateBrandDto, Brand>(createBrandDto);
            _brandService.TAdd(value);
           
            return LocalRedirect("/Admin/Brand/Index");

        }
        else
        {
            foreach (var item in validator.Errors)
            {
                ModelState.AddModelError(item.PropertyName,
                  item.ErrorMessage);

            }
            return View(createBrandDto);
        }

    }

    public IActionResult DeleteBrand(int id)
    {
        var values =_brandService.TGetByID(id);
      _brandService.TDelete(values);
        
        return LocalRedirect("/Admin/Brand/Index");

    }

    [HttpGet]
    public IActionResult UpdateBrand(int id)
    {
        var values = _mapper.Map<UpdateBrandDto>(_brandService.TGetByID(id));
        return View(values);
    }
    public IActionResult UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        var validator = _updateValidator.Validate(updateBrandDto);
        if (validator.IsValid)
        {
            var values = _mapper.Map<UpdateBrandDto, Brand>(updateBrandDto);
         _brandService.TUpdate(values);
            
            return LocalRedirect("/Admin/Brand/Index");
        }
        else
        {
            foreach (var item in validator.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(updateBrandDto);
        }

    }
}
}