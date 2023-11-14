using AutoMapper;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DtoLayer.Dtos.ContactDtos;
using ECommerce.DtoLayer.Dtos.ContactUsDtos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

   

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values =_contactUsService.TGetList();
            return View(values);
        }



        public IActionResult DeleteContactUs(int id)
        {
            var value = _contactUsService.TGetByID(id);
           _contactUsService.TDelete(value);
            return LocalRedirect("/Admin/ContactUs/Index");
        }
    }
}
