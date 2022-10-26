
using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ApplicationClient.Contracts.Persistence.Repositories;
using BancoSolidario.Common.CommonExtendEntity;
using BancoSolidario.ExtendApplication.Contracts.Persistence;
using BancoSolidario.ExtendInfrastructure.Repositories.Generics;
using BancoSolidario.InfrastructureClient.Persistence;
using BancoSolidario.InfrastructureClient.Repositories.Client;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BancoSolidario.InfrastructureClient.Repositories
{
    public class UnitOfWorkAppClient : IUnitOfWorkAppClient
    {
        private Hashtable _repositories; // objeto collection para los repositories
        private readonly BcoSolidarioClientContext _context;

        private IClientRepository _clientRepository;

        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);


        public UnitOfWorkAppClient(BcoSolidarioClientContext context)
        {
            _context = context ??
           throw new ArgumentNullException(nameof(context));

        }


        public async Task<int> Complete(string token)
        {
            if (token != null)
            {

                foreach (var entry in _context.ChangeTracker.Entries<BaseDomainModel>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = token;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = token;
                            break;
                    }
                }
                return await _context.SaveChangesAsync();

            }
            else return 0;

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {

            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);

            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
