
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.ApplicationClient.Features.Client.Queries.Vms
{
    public class ClientVm : BaseDomainModel
    {
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }

    }
}
