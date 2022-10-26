
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.ChangeActivators
{
    public class TiempoPlanDeAhorroChangeActivatorsCommand : ExtendChangeActivatorsCommand, IRequest<ResponseChangeActivators>
    {
        public Guid Id { get; set; }


        public TiempoPlanDeAhorroChangeActivatorsCommand(Guid id)
        {
            Id = id;
        }

        public TiempoPlanDeAhorroChangeActivatorsCommand()
        {
        }
    }
}
