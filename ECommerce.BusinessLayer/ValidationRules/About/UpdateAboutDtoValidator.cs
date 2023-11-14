using ECommerce.DtoLayer.Dtos.AboutDtos;
using FluentValidation;

namespace ECommerce.BusinessLayer.ValidationRules.About
{
    public class UpdateAboutDtoValidator : AbstractValidator<UpdateAboutDto>
    {
        public UpdateAboutDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama").WithMessage(ValidationMessages.NotEmpty)
                .MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage)
                .MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}
