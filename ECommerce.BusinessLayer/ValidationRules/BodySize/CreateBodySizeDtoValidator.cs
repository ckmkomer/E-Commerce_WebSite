using ECommerce.DtoLayer.Dtos.BodySizeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.BodySize
{
    public class CreateBodySizeDtoValidator : AbstractValidator<CreateBodySizeDto>
    {
        public CreateBodySizeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Beden bilgisi").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
