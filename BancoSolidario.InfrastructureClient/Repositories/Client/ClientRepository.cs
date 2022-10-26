
using BancoSolidario.ApplicationClient.Contracts.Persistence.Repositories;
using BancoSolidario.ExtendInfrastructure.Repositories.Generics;
using BancoSolidario.InfrastructureClient.Persistence;

namespace BancoSolidario.InfrastructureClient.Repositories.Client
{
    public class ClientRepository
    : RepositoryBase<BancoSolidario.Client.Entities.Client>, IClientRepository
    {
        public ClientRepository(BcoSolidarioClientContext context) : base(context)
        {
        }
    }
}
