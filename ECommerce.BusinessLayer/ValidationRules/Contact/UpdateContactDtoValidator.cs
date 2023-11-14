using ECommerce.DtoLayer.Dtos.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.Contact
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(x => x.Adress).NotEmpty().WithName("Adres").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
            RuleFor(x => x.Phone).NotEmpty().WithName("Telefon").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Email).NotEmpty().WithName("Mail").WithMessage(ValidationMessages.NotEmpty);
            
            RuleFor(x => x.Iframe).NotEmpty().WithName("Harita url").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
