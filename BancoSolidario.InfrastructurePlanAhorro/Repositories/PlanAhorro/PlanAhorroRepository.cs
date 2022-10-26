
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence.Repositories;
using BancoSolidario.ExtendInfrastructure.Repositories.Generics;
using BancoSolidario.InfrastructurePlanAhorro.Persistence;

namespace BancoSolidario.InfrastructurePlanAhorro.Repositories.PlanAhorro
{
    public class PlanAhorroRepository
    : RepositoryBase<NuevoPlanAhorro.Entities.PlanAhorro>, IPlanAhorroRepository
    {
        public PlanAhorroRepository(NuevoPlanAhorroContext context) : base(context)
        {
        }
    }
}
