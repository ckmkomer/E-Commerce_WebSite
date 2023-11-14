using ECommerce.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.EntityLayer.Concrete;
using ECommerce.BusinessLayer.Abstract;

namespace ECommerce.BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void AddToCart(int UserId, int productId, int quantity)
        {
           var cart = GetCartByUserId(UserId);
            if (cart != null)
            {
                var index=cart.CartItems.FindIndex(x => x.ProductId == productId);
                if (index<0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id

                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                _cartDal.Update(cart);
            }
        }

        public void DeleteCartItem(int userId, int productId)
        {
            var cart = GetCartByUserId(userId);

            if (cart != null)
            {
                // Sepetteki belirli ürünü bul ve sil
                var cartItem = cart.CartItems.SingleOrDefault(ci => ci.ProductId == productId);

                if (cartItem != null)
                {
                    _cartDal.DeleteCartItem(cart, cartItem);
                }
            }
        }


        public Cart GetCartByUserId(int UserId)
        {
            return _cartDal.GetByUserId(UserId);
        }

        public void InitializeCart(int userId)
        {
            _cartDal.Insert(new Cart() { UserId = userId });
        }
    }
}
