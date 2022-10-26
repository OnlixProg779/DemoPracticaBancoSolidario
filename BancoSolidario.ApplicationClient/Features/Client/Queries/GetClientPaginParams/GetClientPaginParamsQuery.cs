using BancoSolidario.ApplicationClient.Features.Client.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.GetClientPaginParams
{
    public class GetClientPaginParamsQuery : PaginationBaseQuery, IRequest<PaginationVm<ClientVm>>
    {
        public ClientPaginParams ClientPaginParams { get; set; }

        public GetClientPaginParamsQuery()
        {
            ClientPaginParams = new ClientPaginParams();
        }
    }

    public class ClientPaginParams : StandarBaseQuery
    {
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }

    }
}
