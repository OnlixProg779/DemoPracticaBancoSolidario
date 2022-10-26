
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationPlanAhorro.Specifications.TiempoPlanDeAhorro
{
    public class TiempoPlanDeAhorroForCountingSpecification : BaseSpecification<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>
    {
        public TiempoPlanDeAhorroForCountingSpecification(List<Expression<Func<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro, bool>>> criteria)
            : base(criteria)
        {

        }
    }
}
