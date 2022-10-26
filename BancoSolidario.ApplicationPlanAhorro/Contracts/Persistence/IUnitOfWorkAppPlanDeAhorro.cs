using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence.Repositories;
using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Contracts.Persistence;

namespace BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence
{
    public interface IUnitOfWorkAppPlanDeAhorro : IDisposable
    {

        ITiempoPlanDeAhorroRepository TiempoPlanDeAhorroRepository { get; }
        IPlanAhorroRepository PlanAhorroRepository { get; }



        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete(string token);
    }
}
