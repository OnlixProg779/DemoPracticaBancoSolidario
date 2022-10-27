using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Commands.CreatePlanAhorro
{
    public class CreatePlanAhorroCommand: ExtendCreateCommand, IRequest<PlanAhorroVm>
    {

        public string? ClientRef { get; set; }
        public float? MontoDeAhorro { get; set; }
        public string? TiempoPlanDeAhorroId { get; set; } 

    }
}
