using Ecommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class Cart :BaseEntity
    {
        public int UserId { get; set; }

        public List<CartItem> CartItems{ get; set;} 

    }
}
