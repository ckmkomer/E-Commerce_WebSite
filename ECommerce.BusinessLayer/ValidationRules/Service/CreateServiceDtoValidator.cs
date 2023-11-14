using DtoLayer.Dtos.ServiceDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.Service
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
        
        }
    }
}
