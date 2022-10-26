

using BancoSolidario.ExtendApplication.Contracts.Persistence;
using BancoSolidario.NuevoPlanAhorro.Entities;

namespace BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence.Repositories
{
    public interface IPlanAhorroRepository : IAsyncRepository<PlanAhorro>
    {
    }
}
