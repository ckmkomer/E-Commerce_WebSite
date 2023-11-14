using Ecommerce.CoreLayer.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
   public interface ICartDal:IGenericDal<Cart>
    {
        Cart GetByUserId(int userId);

        void DeleteFromCart(int cartId, int productId);

        void DeleteCartItem(Cart cart, CartItem cartItem);
       
    }
}
