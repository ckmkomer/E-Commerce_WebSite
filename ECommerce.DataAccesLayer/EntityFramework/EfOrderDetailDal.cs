using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderItem>, IOrderDetailDal
    {
        public EfOrderDetailDal(Context context) : base(context)
        {
        }
    }
}
