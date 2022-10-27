using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Commands.CreateTiempoPlanDeAhorroAhorro
{
    public class CreateTiempoPlanDeAhorroCommand: ExtendCreateCommand, IRequest<TiempoPlanDeAhorroVm>
    {

        public int? Meses { get; set; }
        public float? TasaDeInteresAnual { get; set; }
        public string? TipoDeInteres { get; set; }

    }
}
