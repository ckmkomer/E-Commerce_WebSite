using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DtoLayer.Dtos.FeatureDtos
{
  public class ResultFeatureDto
    {
        public int Id { get; set; }
        public string? Title{ get; set; }

        public string? Description { get; set; }
        public string? ImageURl { get; set; }
        
    }
}
