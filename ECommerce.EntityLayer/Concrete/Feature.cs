using Ecommerce.CoreLayer.Entities;

namespace ECommerce.EntityLayer.Concrete
{
    public class Feature :BaseEntity
    {
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        public string? ImageURl { get; set; }
        
    }
}
