using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.Dtos.ContactUsDtos
{
    public class UpdateContactUsDto
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string Message { get; set; }
        
    }
}
