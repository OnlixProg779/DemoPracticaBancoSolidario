using FluentValidation;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.CreatePlanAhorro
{
    public class CreatePlanAhorroCommandValidator : AbstractValidator<CreatePlanAhorroCommand>
    {
        public CreatePlanAhorroCommandValidator()
        {
            RuleFor(entity => entity.MontoDeAhorro)
                .NotEmpty()
                .Must(MontoDeAhorro => MontoDeAhorro.Value > 99).WithMessage("el monto ingresado debe ser almenos de $100");
            RuleFor(entity => entity.TiempoPlanDeAhorroId)
                .NotEmpty();
            RuleFor(entity => entity.ClientRef)
                .NotEmpty();
        }
    }
}
