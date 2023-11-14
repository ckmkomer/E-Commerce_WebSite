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
    public class BrandManager : IBrandService
    {
        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }

        public void TAdd(Brand t)
        {
           _BrandDal.Insert(t);
        }

        public void TDelete(Brand t)
        {
            _BrandDal.Delete(t);
        }

        public Brand TGetByID(int id)
        {
           return _BrandDal.GetByID(id);
        }

        public List<Brand> TGetList()
        {
          return  _BrandDal.GetList();
        }

        public List<Brand> TGetListbyFilter(int id)
        {
            return _BrandDal.GetByFilter(x => x.Id == id);
        }

        public void TUpdate(Brand t)
        {
            _BrandDal.Update(t);
        }
    }
}
