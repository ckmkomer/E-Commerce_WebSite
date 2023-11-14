using Ecommerce.CoreLayer.GenericService;
using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TAdd(ContactUs t)
        {
           _contactUsDal.Insert(t);
        }

        public void TDelete(ContactUs t)
        {
            _contactUsDal.Delete(t);
        }

        public ContactUs TGetByID(int id)
        {
           return _contactUsDal.GetByID(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListbyFilter(int id)
        {
           return _contactUsDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(ContactUs t)
        {
            _contactUsDal.Update(t);
        }
    }
}
