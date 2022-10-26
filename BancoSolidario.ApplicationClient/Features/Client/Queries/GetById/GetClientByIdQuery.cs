using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.GetById
{
    public class GetClientByIdQuery
    : ExtendGetQuery, IRequest<ClientVm>
    {
        public Guid? Id { get; set; }

        public GetClientByIdQuery(Guid? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
