using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ContactDtos;
using ECommerce.DtoLayer.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {


		private readonly IMapper _mapper;
		private readonly IContactService _contactService;

		public ContactList(IMapper mapper, IContactService contactService)
		{
			_mapper = mapper;
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetList());
			return View(values);
		}
		
	}
}
