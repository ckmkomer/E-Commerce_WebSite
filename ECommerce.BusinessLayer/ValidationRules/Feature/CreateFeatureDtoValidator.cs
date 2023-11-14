using ECommerce.DtoLayer.Dtos.FeatureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.Feature
{
    public class CreateFeatureDtoValidator : AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Özellik bilgisi").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
