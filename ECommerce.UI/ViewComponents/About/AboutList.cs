using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        private IAboutService _aboutService;
        private IMapper _mapper;

        public AboutList(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetList());
            return View(values);
        }
    }
}
