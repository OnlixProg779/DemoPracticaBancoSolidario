using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.GetById
{
    public class GetClientByIdQuery
    : ExtendGetQuery, IRequest<ClientVm>
    {
        public string? Id { get; set; }

        public GetClientByIdQuery(string? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
