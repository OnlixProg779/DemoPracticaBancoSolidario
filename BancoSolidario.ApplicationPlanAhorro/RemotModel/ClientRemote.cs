using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.ApplicationPlanAhorro.RemotModel
{
    public class ClientRemote: BaseDomainModel
    {
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;

    }
}
