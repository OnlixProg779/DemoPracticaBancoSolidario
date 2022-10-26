using BancoSolidario.ApplicationClient.Contracts.Persistence.Repositories;
using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Contracts.Persistence;

namespace BancoSolidario.ApplicationClient.Contracts.Persistence
{
    public interface IUnitOfWorkAppClient : IDisposable
    {

        IClientRepository ClientRepository { get; }



        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete(string token);
    }
}
