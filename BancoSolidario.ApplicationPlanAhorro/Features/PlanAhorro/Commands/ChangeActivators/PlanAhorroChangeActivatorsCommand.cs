
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.ChangeActivators
{
    public class PlanAhorroChangeActivatorsCommand : ExtendChangeActivatorsCommand, IRequest<ResponseChangeActivators>
    {
        public Guid Id { get; set; }


        public PlanAhorroChangeActivatorsCommand(Guid id)
        {
            Id = id;
        }

        public PlanAhorroChangeActivatorsCommand()
        {
        }
    }
}
