
using BancoSolidario.ExtendApplication.Specifications;
using System.Linq.Expressions;

namespace BancoSolidario.ApplicationPlanAhorro.Specifications.PlanAhorro
{
    public class PlanAhorroForCountingSpecification : BaseSpecification<NuevoPlanAhorro.Entities.PlanAhorro>
    {
        public PlanAhorroForCountingSpecification(List<Expression<Func<NuevoPlanAhorro.Entities.PlanAhorro, bool>>> criteria)
            : base(criteria)
        {

        }
    }
}
