using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.NuevoPlanAhorro.Entities
{
    [Table("PlanAhorro")]
    public class PlanAhorro: BaseDomainModel
    {
        public PlanAhorro()
        {

        }

        public string ClientRef { get; set; } = null!;
        public string MontoDeAhorro { get; set; } = null!;
        public string TiempoPlanDeAhorroId { get; set; } = null!;

        [ForeignKey(nameof(TiempoPlanDeAhorroId))]
        [InverseProperty("PlanesDeAhorro")]
        public virtual TiempoPlanDeAhorro? TiempoPlanDeAhorro { get; set; }
    }
}
