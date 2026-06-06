using FluentValidation;
using PremierLigApi.Dtos.MatchStatisticDtos;

namespace PremierLigApi.Validators.MatchStatisticValidators
{
    public class CreateMatchStatisticDtoValidator : AbstractValidator<CreateMatchStatisticDto>
    {
        public CreateMatchStatisticDtoValidator()
        {
            RuleFor(x => x.MatchId)
                .NotEmpty();

            RuleFor(x => x.HomeYellowCards)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.AwayYellowCards)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.HomeRedCards)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.AwayRedCards)
                .GreaterThanOrEqualTo(0);
        }
    }
}
