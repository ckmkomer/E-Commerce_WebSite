using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
  public interface ICartService
    {
        void InitializeCart(int UserId);

        Cart GetCartByUserId(int UserId);

        void AddToCart(int UserId ,int productId,int quantity);
        void DeleteCartItem(int UserId, int productId);
    }
}
