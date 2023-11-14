using ECommerce.DtoLayer.Dtos.SocialMediaDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.SocialMedia
{
    public class CreateSocialMediaDtoValidator : AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaDtoValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithName("Icon").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Name).NotEmpty().WithName("İsim").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Url).NotEmpty().WithName("Url").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
