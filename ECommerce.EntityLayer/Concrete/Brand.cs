using Ecommerce.CoreLayer.Entities;

namespace ECommerce.EntityLayer.Concrete
{
    public class Brand  :BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
