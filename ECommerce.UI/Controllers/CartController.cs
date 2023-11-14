using ECommerce.BusinessLayer.Abstract;
using ECommerce.EntityLayer.Concrete.Identity;
using ECommerce.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.PresentationLayer.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<AppUser> _userManager;

        public CartController(ICartService cartService, UserManager<AppUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int userIdAsInt))
            {
                var cart = _cartService.GetCartByUserId(userIdAsInt);

                if (cart != null)
                {
                    return View(new CartModel
                    {
                        CartId = cart.Id,
                        CartItems = cart.CartItems.Select(x => new CartItemModel
                        {
                            CartItemId = x.Id,
                            Name = x.product.Name,
                            Price = x.product.Price,
                            ImageUrl = x.product.Image,
                            ProductId = x.product.Id,
                            Quantity = x.Quantity
                        }).ToList()
                    });
                }
                else
                {

                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int userIdAsInt))
            {


                _cartService.AddToCart(userIdAsInt, productId, quantity);
                return LocalRedirect("/Home/Index");
            }

            return View("Home", "Index");

        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);

            if (int.TryParse(userId, out int userIdAsInt))
            {
                _cartService.DeleteCartItem(userIdAsInt, productId);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                if (int.TryParse(userId, out int userIdAsInt))
                {
                    var cart = _cartService.GetCartByUserId(userIdAsInt);

                    var orderModel = new OrderModel
                    {
                        
                        CartModel = new CartModel
                        {
                            CartId = cart.Id,
                            CartItems = cart.CartItems.Select(x => new CartItemModel
                            {
                                CartItemId = x.Id,
                                ProductId = x.product.Id,
                                Name = x.product.Name,
                                Price = (decimal)x.product.Price,
                                ImageUrl = x.product.Image,
                                Quantity = x.Quantity
                            }).ToList()
                        }
                    };


                    TempData["SuccessMessage"] = "Ödeme İşlemlerine geçebilirsiniz.";

                    return View(orderModel);

                }
            }


            TempData["ErrorMessage"] = "Sipariş oluşturulurken bir hata oluştu.";

            return RedirectToAction("Error");
        }



        public IActionResult EndOrder() 
        {
            TempData["SuccessMessage1"] = "Sayın Ömer Çakmak";
            TempData["SuccessMessage2"] = "Ödeme İşleminiz başarılı bir şekilde tamamlanmıştır..";
            TempData["SuccessMessage3"] = "Sipariş numaranız 1232111111";
            
            return View();
        }


    }
}




