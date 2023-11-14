using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public EfContactUsDal(Context context) : base(context)
        {
        }
    }
}
