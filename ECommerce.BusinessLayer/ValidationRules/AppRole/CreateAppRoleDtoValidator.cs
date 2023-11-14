using ECommerce.DtoLayer.Dtos.AppRoleDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.AppRole
{
    public class CreateAppRoleDtoValidator : AbstractValidator<CreateAppRoleDto>
    {
        public CreateAppRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Rol adı").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}
