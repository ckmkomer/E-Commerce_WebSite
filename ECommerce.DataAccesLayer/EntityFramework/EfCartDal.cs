using Ecommerce.CoreLayer.EntityFramework;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using NLog.Fluent;
using System.Diagnostics;

namespace ECommerce.DataAccessLayer.EntityFramework
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        private readonly Context _context;
        public EfCartDal(Context context) : base(context)
        {
        }

        public override void Update(Cart t)
        {
            using (var context = new Context())
            {
                context.Carts.Update(t);
                context.SaveChanges();
            }
        }

        public Cart GetByUserId(int userId)
        {
            using (var context = new Context())
            {
                var cart = context
                    .Carts
                    .Include(x => x.CartItems)
                    .ThenInclude(x => x.product)
                    .FirstOrDefault(x => x.UserId == userId);

                // Loglama ekleyin
                Log.Info($"GetByUserId - UserId: {userId}, Cart: {(cart == null ? "null" : "not null")}");

                return cart;
            }
        }


        public void DeleteFromCart(int cartId, int productId)
		{
			using(var context = new Context())
            {
                context.Carts.ExecuteDelete();
                context.SaveChanges();
            }
		}

        public void DeleteCartItem(Cart cart, CartItem cartItem)
        {
          
            

            using (var context = new Context())
            {
                context.CartItems.Remove(cartItem);
                context.SaveChanges();
            }
        }

    }
}
