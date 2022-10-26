using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetById
{
    public class GetTiempoPlanDeAhorroByIdQuery
    : ExtendGetQuery, IRequest<TiempoPlanDeAhorroVm>
    {
        public string? Id { get; set; }

        public GetTiempoPlanDeAhorroByIdQuery(string? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
