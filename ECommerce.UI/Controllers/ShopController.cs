using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
	{
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductDto> _createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;

        public ShopController(IMapper mapper, IProductService productService, IValidator<CreateProductDto> createValidator, IValidator<UpdateProductDto> updateValidator)
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
    }
}
