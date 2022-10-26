
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.ApplicationPlanAhorro.Features.TiempoPlanDeAhorro.Queries.Vms
{
    public class TiempoPlanDeAhorroVm : BaseDomainModel
    {
        public int? Meses { get; set; }
        public float? TasaDeInteresAnual { get; set; }
        public string? TipoDeInteres { get; set; }
    }
}
