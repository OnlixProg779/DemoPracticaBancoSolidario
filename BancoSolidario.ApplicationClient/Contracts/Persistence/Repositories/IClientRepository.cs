
using BancoSolidario.ExtendApplication.Contracts.Persistence;

namespace BancoSolidario.ApplicationClient.Contracts.Persistence.Repositories
{
    public interface IClientRepository : IAsyncRepository<Client.Entities.Client>
    {
    }
}
