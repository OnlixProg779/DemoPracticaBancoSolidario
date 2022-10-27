using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Commands.CreatePlanAhorro
{
    public class CreateClientCommand: ExtendCreateCommand, IRequest<ClientVm>
    {
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }

    }
}
