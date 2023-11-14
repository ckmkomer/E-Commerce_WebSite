using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        IContactUsService _contactUsService;

		public ContactController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult SendMessage(ContactUs contactUs)
		{
          _contactUsService.TAdd(contactUs);
            return LocalRedirect("/Contact/Index");
        }

		public IActionResult MapPartial()
        {
            return View();
        }



    }
}
