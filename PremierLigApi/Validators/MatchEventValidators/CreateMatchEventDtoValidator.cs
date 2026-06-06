using FluentValidation;
using PremierLigApi.Dtos.MatchEventDtos;

namespace PremierLigApi.Validators.MatchEventValidators
{
    public class CreateMatchEventDtoValidator : AbstractValidator<CreateMatchEventDto>
    {
        public CreateMatchEventDtoValidator()
        {
            RuleFor(x => x.MatchId)
                .NotEmpty();

            RuleFor(x => x.TeamId)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Minute)
                .InclusiveBetween(1, 120);
        }
    }
}
