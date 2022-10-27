
using BancoSolidario.ExtendApplication.Features.Shared.Commands;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Commands.ChangeActivators
{
    public class ClientChangeActivatorsCommand : ExtendChangeActivatorsCommand, IRequest<ResponseChangeActivators>
    {
        public string Id { get; set; }


        public ClientChangeActivatorsCommand(string id)
        {
            Id = id;
        }

        public ClientChangeActivatorsCommand()
        {
        }
    }
}
