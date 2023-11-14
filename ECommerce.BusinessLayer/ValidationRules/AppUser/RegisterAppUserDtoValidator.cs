using ECommerce.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.AppUser
{
    public class RegisterAppUserDtoValidator : AbstractValidator<RegisterAppUserDto>
    {
        public RegisterAppUserDtoValidator() {

            RuleFor(x => x.Name).NotEmpty().WithName("Ad").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Surname).NotEmpty().WithName("Soyad").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Email).NotEmpty().WithName("E-mail").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.UserName).NotEmpty().WithName("Kullanıcı adı").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
            RuleFor(x => x.Password).NotEmpty().WithName("Şifre").WithMessage(ValidationMessages.Equal);
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithName("Şifre Tekrar").WithMessage(ValidationMessages.Equal);
        }
    }
}
