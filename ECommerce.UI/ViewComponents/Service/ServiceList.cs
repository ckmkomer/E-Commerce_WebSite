using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        private IServiceService _serviceservice;
        private IMapper _mapper;

        public ServiceList(IServiceService serviceservice, IMapper mapper)
        {
            _serviceservice = serviceservice;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<ResultServiceDto>>(_serviceservice.TGetList());
            return View(values);
        }
    }
}

