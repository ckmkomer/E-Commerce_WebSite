using Ecommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class CartItem :BaseEntity
    {
        public Product product { get; set; }
        public int ProductId { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set;}

        public int Quantity { get; set; }

    }
}
