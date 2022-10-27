using BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.GetPlanAhorroPaginParams
{
    public class GetPlanAhorroPaginParamsQuery : PaginationBaseQuery, IRequest<PaginationVm<PlanAhorroVm>>
    {
        public PlanAhorroPaginParams PlanAhorroPaginParams { get; set; }

        public GetPlanAhorroPaginParamsQuery()
        {
            PlanAhorroPaginParams = new PlanAhorroPaginParams();
        }
    }

    public class PlanAhorroPaginParams : StandarBaseQuery
    {
        public string? ClientRef { get; set; }
        public float? MontoDeAhorro { get; set; }
        public string? TiempoPlanDeAhorroId { get; set; }

    }
}
