
using BancoSolidario.ApplicationPlanAhorro.RemotModel;

namespace BancoSolidario.NuevoPlanAhorro.API.RemoteContracts
{
    public interface IClientServices
    {
      Task<(bool resultado, ClientRemote client, string ErrorMessage)>  GetClient(string id);
    }
}
