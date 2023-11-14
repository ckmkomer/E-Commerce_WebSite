using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetProductListWithCategory(int id)
        {
            return _productDal.GetProductListWithCategory();
        }

        public void TAdd(Product t)
        {
            _productDal.Update(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public Product TGetByID(int id)
        {
          return  _productDal.GetByID(id);
        }

        public List<Product> TGetList()
        {
           return
                _productDal.GetList();
        }

        public List<Product> TGetListbyFilter(int id)
        {
            return _productDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
