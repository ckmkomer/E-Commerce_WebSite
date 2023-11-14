using DtoLayer.Dtos.ServiceDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.Service
{
    public class UpdateServiceDtoValidator : AbstractValidator<UpdateServiceDto>
    {
        public UpdateServiceDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
           
        }
    }
}
