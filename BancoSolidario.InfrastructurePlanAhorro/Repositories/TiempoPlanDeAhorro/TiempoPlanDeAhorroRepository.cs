
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence.Repositories;
using BancoSolidario.ExtendInfrastructure.Repositories.Generics;
using BancoSolidario.InfrastructurePlanAhorro.Persistence;

namespace BancoSolidario.InfrastructurePlanAhorro.Repositories.TiempoPlanDeAhorro
{
    public class TiempoPlanDeAhorroRepository
     : RepositoryBase<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>, ITiempoPlanDeAhorroRepository
    {
        public TiempoPlanDeAhorroRepository(NuevoPlanAhorroContext context) : base(context)
        {
        }
    }

}
