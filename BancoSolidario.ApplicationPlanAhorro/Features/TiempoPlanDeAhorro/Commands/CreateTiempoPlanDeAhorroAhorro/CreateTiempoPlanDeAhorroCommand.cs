using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.CreateTiempoPlanDeAhorroAhorro
{
    public class CreateTiempoPlanDeAhorroCommand: ExtendCreateCommand, IRequest<TiempoPlanDeAhorroVm>
    {

        public string? ClientRef { get; set; }
        public string? MontoDeAhorro { get; set; }
        public string? TiempoPlanDeAhorroId { get; set; } 

    }
}
