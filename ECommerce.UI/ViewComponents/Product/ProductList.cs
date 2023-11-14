using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents.About
{
    public class ProductList : ViewComponent
    {
        private IProductService _productService;
       private IMapper _mapper;

        public ProductList(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetList());
            return View(values);
        }
    }
}
