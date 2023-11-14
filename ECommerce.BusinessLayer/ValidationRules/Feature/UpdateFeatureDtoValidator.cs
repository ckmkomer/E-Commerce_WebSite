using ECommerce.DtoLayer.Dtos.FeatureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.Feature
{
    public class UpdateFeatureDtoValidator : AbstractValidator<UpdateFeatureDto>
    {
        public UpdateFeatureDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Özellik bilgisi").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
