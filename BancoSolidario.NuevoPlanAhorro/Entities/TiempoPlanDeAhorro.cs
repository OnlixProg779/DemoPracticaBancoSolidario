using System.ComponentModel.DataAnnotations.Schema;
using BancoSolidario.Common.CommonExtendEntity;

namespace BancoSolidario.NuevoPlanAhorro.Entities
{
    [Table("TiempoPlanDeAhorro")]
    public class TiempoPlanDeAhorro : BaseDomainModel
    {
        public TiempoPlanDeAhorro()
        {
            PlanesDeAhorro = new HashSet<PlanAhorro>();

        }

        public int Meses { get; set; }
        public float TasaDeInteresAnual { get; set; }
        public string TipoDeInteres { get; set; } = null!;

        [InverseProperty(nameof(PlanAhorro.TiempoPlanDeAhorro))]
        public virtual ICollection<PlanAhorro> PlanesDeAhorro { get; set; }
    }
}
