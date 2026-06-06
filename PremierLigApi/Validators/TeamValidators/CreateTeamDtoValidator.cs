using FluentValidation;
using PremierLigApi.Dtos.TeamDtos;

namespace PremierLigApi.Validators.TeamValidators
{
    public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
    {
        public CreateTeamDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Takım adı boş geçilemez.");

            RuleFor(x => x.ShortName)
                .NotEmpty().WithMessage("Kısa ad boş geçilemez.")
                .MaximumLength(5).WithMessage("Kısa ad en fazla 5 karakter olabilir.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir boş geçilemez.");

            RuleFor(x => x.StadiumName)
                .NotEmpty().WithMessage("Stadyum adı boş geçilemez.");
        }
    }
}
