
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.ChangeActivators
{
    public class TiempoPlanDeAhorroChangeActivatorsCommand : ExtendChangeActivatorsCommand, IRequest<ResponseChangeActivators>
    {
        public string Id { get; set; }


        public TiempoPlanDeAhorroChangeActivatorsCommand(string id)
        {
            Id = id;
        }

        public TiempoPlanDeAhorroChangeActivatorsCommand()
        {
        }
    }
}
