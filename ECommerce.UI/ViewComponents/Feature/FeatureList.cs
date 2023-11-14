using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents.About
{
	public class FeatureList : ViewComponent
    {
        private IFeatureService _featureService;
        private IMapper _mapper;

        public FeatureList(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetList());
            return View(values);
        }
    }
}
