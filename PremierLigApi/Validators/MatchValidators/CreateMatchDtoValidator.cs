using FluentValidation;
using PremierLigApi.Dtos.MatchDtos;

namespace PremierLigApi.Validators.MatchValidators
{
    public class CreateMatchDtoValidator : AbstractValidator<CreateMatchDto>
    {
        public CreateMatchDtoValidator()
        {
            RuleFor(x => x.HomeTeamId)
                .NotEmpty();

            RuleFor(x => x.AwayTeamId)
                .NotEmpty();

            RuleFor(x => x.HomeTeamId)
                .NotEqual(x => x.AwayTeamId)
                .WithMessage("Ev sahibi ve deplasman takımı aynı olamaz.");

            RuleFor(x => x.Stadium)
                .NotEmpty();

            RuleFor(x => x.Week)
                .InclusiveBetween(1, 38);
        }
    }
}
