using ECommerce.DtoLayer.Dtos.FeatureDtos;
using ECommerce.DtoLayer.Dtos.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.Product
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("İsim bilgisi").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
