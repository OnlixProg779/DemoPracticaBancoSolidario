
using BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms;
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.ApplicationPlanAhorro.Features.PlanAhorro.Queries.Vms
{
    public class PlanAhorroVm : BaseDomainModel
    {
        public string? ClientRef { get; set; }
        public float? MontoDeAhorro { get; set; }
        public string? TiempoPlanDeAhorroId { get; set; }

        public virtual TiempoPlanDeAhorroVm? TiempoPlanDeAhorro { get; set; }

    }
}
