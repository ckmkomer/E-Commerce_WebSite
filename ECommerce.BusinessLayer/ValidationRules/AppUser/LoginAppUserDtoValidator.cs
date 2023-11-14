using ECommerce.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.AppUser
{
    public class LoginAppUserDtoValidator : AbstractValidator<LoginAppUserDto>
    {
        public LoginAppUserDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithName("Kullanıcı adı").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithName("Şifre").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
