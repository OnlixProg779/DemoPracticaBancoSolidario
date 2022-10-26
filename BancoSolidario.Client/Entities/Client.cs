
using BancoSolidario.Common.CommonExtendEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSolidario.Client.Entities
{
    [Table("Client")]
    public class Client : BaseDomainModel
    {
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }
}
