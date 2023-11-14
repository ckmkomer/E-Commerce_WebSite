using Ecommerce.CoreLayer.Entities;

namespace ECommerce.EntityLayer.Concrete
{
    public class Calor :BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; } = new();
       
    }
}
