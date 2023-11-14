namespace ECommerce.UI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }


        public decimal TotalPrice ()
        {
            return CartItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
