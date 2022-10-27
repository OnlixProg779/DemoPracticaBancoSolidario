using BancoSolidario.NuevoPlanAhorro.API.RemotModel;

namespace BancoSolidario.NuevoPlanAhorro.API.RemoteContracts
{
    public interface IClientServices
    {
      Task<(bool resultado, ClientRemote, string ErrorMessage)>  GetClient(string id);
    }
}
