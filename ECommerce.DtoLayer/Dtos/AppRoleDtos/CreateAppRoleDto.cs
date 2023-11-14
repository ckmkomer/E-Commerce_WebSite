using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.Dtos.AppRoleDtos
{
    public class CreateAppRoleDto
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz.")]
        public string Name { get; set; }
    }
}
