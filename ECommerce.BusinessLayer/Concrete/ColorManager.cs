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
    public class ColorManager : IColorService
    {

        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void TAdd(Calor t)
        {
          _colorDal.Insert(t);
        }

        public void TDelete(Calor t)
        {
            _colorDal.Delete(t);
        }

        public Calor TGetByID(int id)
        {
           return _colorDal.GetByID(id);
        }

        public List<Calor> TGetList()
        {
           return _colorDal.GetList();
       }

        public List<Calor> TGetListbyFilter(int id)
        {
            return _colorDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(Calor t)
        {
            _colorDal.Update(t);
        }
    }
}
