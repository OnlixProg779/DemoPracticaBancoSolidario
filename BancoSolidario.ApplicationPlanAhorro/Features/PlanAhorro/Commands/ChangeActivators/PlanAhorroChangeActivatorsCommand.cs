
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.ChangeActivators
{
    public class PlanAhorroChangeActivatorsCommand : ExtendChangeActivatorsCommand, IRequest<ResponseChangeActivators>
    {
        public string Id { get; set; }


        public PlanAhorroChangeActivatorsCommand(string id)
        {
            Id = id;
        }

        public PlanAhorroChangeActivatorsCommand()
        {
        }
    }
}
