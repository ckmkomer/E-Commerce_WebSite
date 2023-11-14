using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.Dtos.ProductDetailDtos
{
    public class CreateProductDetailDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string CoverImage { get; set; }
        public string İmage1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductID { get; set; }
    }
}
