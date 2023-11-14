using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductDto> _createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;

        public ProductController(IMapper mapper, IProductService productService, IValidator<CreateProductDto> createValidator, IValidator<UpdateProductDto> updateValidator)
        {
            _mapper = mapper;
            _productService = productService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProductDto)
        {
            var validator = _createValidator.Validate(createProductDto);

            if (validator.IsValid)
            {
                var value = _mapper.Map<CreateProductDto, Product>(createProductDto);
                _productService.TAdd(value);

                return LocalRedirect("/Admin/Product/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createProductDto);
            }
        }

        public IActionResult DeleteProduct(int id)
        {
            var serviceID = _productService.TGetByID(id);
           _productService.TDelete(serviceID);
            return LocalRedirect("/Admin/Product/Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _mapper.Map<UpdateProductDto>(_productService.TGetByID(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var validator = _updateValidator.Validate(updateProductDto);

            if (validator.IsValid)
            {
                var value = _mapper.Map<UpdateProductDto, Product>(updateProductDto);
                _productService.TUpdate(value);

                return LocalRedirect("/Admin/Product/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateProductDto);
            }
        }
    }
}
