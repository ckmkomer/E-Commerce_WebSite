using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfColorDal : GenericRepository<Calor>, IColorDal
    {
        public EfColorDal(Context context) : base(context)
        {
        }
    }
}
