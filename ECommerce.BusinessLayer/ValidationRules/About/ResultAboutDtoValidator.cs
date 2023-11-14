using ECommerce.DtoLayer.Dtos.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.ValidationRules.About
{
    public class ResultAboutDtoValidator : AbstractValidator<ResultAboutDto>
    {
        public ResultAboutDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama").WithMessage(ValidationMessages.NotEmpty)
                .MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage)
                .MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}
