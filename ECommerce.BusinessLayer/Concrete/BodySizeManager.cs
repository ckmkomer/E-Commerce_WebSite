using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
    public class BodySizeManager : IBodySizeService

    {
        IBodySizeDal _bodySizeDal;

        public BodySizeManager(IBodySizeDal bodySizeDal)
        {
            _bodySizeDal = bodySizeDal;
        }

        public void TAdd(BodySize t)
        {
            _bodySizeDal.Insert(t);
        }

        public void TDelete(BodySize t)
        {
            _bodySizeDal.Delete(t);
        }

        public BodySize TGetByID(int id)
        {
            return _bodySizeDal.GetByID(id);
        }

        public List<BodySize> TGetList()
        {
            return _bodySizeDal.GetList();
        }

        public List<BodySize> TGetListbyFilter(int id)
        {
            return _bodySizeDal.GetByFilter(x => x.Id == id);
        }

       

        public void TUpdate(BodySize t)
        {
           _bodySizeDal.Update(t);
        }
    }
}
