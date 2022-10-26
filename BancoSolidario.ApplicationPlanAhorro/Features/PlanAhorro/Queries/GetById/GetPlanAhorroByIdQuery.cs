using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetById
{
    public class GetPlanAhorroByIdQuery
    : ExtendGetQuery, IRequest<PlanAhorroVm>
    {
        public string? Id { get; set; }

        public GetPlanAhorroByIdQuery(string? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
