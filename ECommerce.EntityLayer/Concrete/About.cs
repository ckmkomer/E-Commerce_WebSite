
using Ecommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.EntityLayer.Concrete
{
    public class About : BaseEntity
    {
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
