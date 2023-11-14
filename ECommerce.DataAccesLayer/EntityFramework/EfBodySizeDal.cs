using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfBodySizeDal : GenericRepository<BodySize>, IBodySizeDal
    {
        public EfBodySizeDal(Context context) : base(context)
        {
        }
    }
}
