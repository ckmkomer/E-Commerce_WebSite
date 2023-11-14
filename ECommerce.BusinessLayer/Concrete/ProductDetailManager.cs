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
    public class ProductDetailManager : IProductDetailService
    {
        IProductDetailDal _productDetailDal;

        public ProductDetailManager(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
        }

        public void TAdd(ProductDetail t)
        {
          _productDetailDal.Insert(t);
        }

        public void TDelete(ProductDetail t)
        {
            _productDetailDal.Delete(t);
        }

        public ProductDetail TGetByID(int id)
        {
            return _productDetailDal.GetByID(id);
        }

        public List<ProductDetail> TGetList()
        {
           return _productDetailDal.GetList();
        }

        public List<ProductDetail> TGetListbyFilter(int id)
        {
           return _productDetailDal.GetByFilter(x => x.Id == id);
        }

        public void TUpdate(ProductDetail t)
        {
            _productDetailDal.Update(t);
        }
    }
}
