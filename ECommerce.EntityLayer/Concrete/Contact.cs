using Ecommerce.CoreLayer.Entities;

namespace ECommerce.EntityLayer.Concrete
{
    public class Contact :BaseEntity
    {
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Iframe { get; set; }
    }
}
