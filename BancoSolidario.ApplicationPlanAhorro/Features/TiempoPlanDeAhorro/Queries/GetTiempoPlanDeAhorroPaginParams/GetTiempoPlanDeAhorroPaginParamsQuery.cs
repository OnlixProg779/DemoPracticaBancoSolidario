using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.ExtendApplication.Features.Shared.Queries;
using MediatR;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.GetTiempoPlanDeAhorroPaginParams
{
    public class GetTiempoPlanDeAhorroPaginParamsQuery : PaginationBaseQuery, IRequest<PaginationVm<TiempoPlanDeAhorroVm>>
    {
        public TiempoPlanDeAhorroPaginParams TiempoPlanDeAhorroPaginParams { get; set; }

        public GetTiempoPlanDeAhorroPaginParamsQuery()
        {
            TiempoPlanDeAhorroPaginParams = new TiempoPlanDeAhorroPaginParams();
        }
    }

    public class TiempoPlanDeAhorroPaginParams : StandarBaseQuery
    {
        public int? Meses { get; set; }
        public float? TasaDeInteresAnual { get; set; }
        public string? TipoDeInteres { get; set; }

    }
}
