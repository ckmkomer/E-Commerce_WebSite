using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ContactDtos;
using ECommerce.EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        private readonly IMapper _mapper;
        private IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IContactService contactService, IMapper mapper, IValidator<UpdateContactDto> updateValidator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public IActionResult UpdateContact(int Id)
        {
            var values = _mapper.Map<UpdateContactDto>(_contactService.TGetByID(1));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var validator = _updateValidator.Validate(updateContactDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateContactDto, Contact>(updateContactDto);
                _contactService.TUpdate(values);
                return View();
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateContactDto);
            }

        }
    }
}
