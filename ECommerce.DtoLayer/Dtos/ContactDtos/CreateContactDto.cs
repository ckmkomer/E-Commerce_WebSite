using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.Dtos.ContactDtos
{
 public class CreateContactDto
    {
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Iframe { get; set; }
    }
}
