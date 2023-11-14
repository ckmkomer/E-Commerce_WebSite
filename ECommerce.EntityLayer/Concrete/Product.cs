using Ecommerce.CoreLayer.Entities;

namespace ECommerce.EntityLayer.Concrete
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

		public ICollection<CartItem> CartItems { get; set; }
		public ICollection<ProductDetail> ProductDetails { get; set; }
       

        //Many-to-Many Relationships
        public List<Calor> Colors { get; } = new();
        public List<BodySize> BodySizes { get; } = new();
    
        
    }
}