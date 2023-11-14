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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category t)
        {
          _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByID(int id)
        {
          return _categoryDal.GetByID(id);
        }

        public List<Category> TGetList()
        {
          return _categoryDal.GetList();
        }

        public List<Category> TGetListbyFilter(int id)
        {
            return _categoryDal.GetByFilter(x=> x.Id == id);
        }

        public void TUpdate(Category t)
        {
           _categoryDal.Update(t);
        }
    }
}
