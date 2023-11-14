using System.Linq.Expressions;

namespace Ecommerce.CoreLayer.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
      
        List<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
