using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.NuevoPlanAhorro.API.RemotModel
{
    public class ClientRemote: BaseDomainModel
    {
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;

    }
}
