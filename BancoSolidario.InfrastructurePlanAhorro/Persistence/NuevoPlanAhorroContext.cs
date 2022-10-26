
using BancoSolidario.Common.CommonExtendEntity;
using Microsoft.EntityFrameworkCore;

namespace BancoSolidario.InfrastructurePlanAhorro.Persistence
{
    public class NuevoPlanAhorroContext : DbContext
    {
        public virtual DbSet<NuevoPlanAhorro.Entities.PlanAhorro>? PlanesDeAhorro { get; set; }
        public virtual DbSet<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>? TiemposParaPlanDeAhorro { get; set; }

        public NuevoPlanAhorroContext(DbContextOptions<NuevoPlanAhorroContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.Active = true;
                        entry.Entity.Editable = true;
                        entry.Entity.Borrable = true;
                        entry.Entity.ShowToUserMed = true;
                        if (string.IsNullOrWhiteSpace(entry.Entity.CreatedBy)) entry.Entity.CreatedBy = "System Default Create";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        if (string.IsNullOrWhiteSpace(entry.Entity.LastModifiedBy)) entry.Entity.LastModifiedBy = "System Default Update";

                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Spain.1252");

            // ESTO ES FLUENT APIs
            modelBuilder.Entity<NuevoPlanAhorro.Entities.TiempoPlanDeAhorro>(entity =>
            {
                //entity.Property(e => e.Id).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))");
            });

            modelBuilder.Entity<NuevoPlanAhorro.Entities.PlanAhorro>(entity =>
            {
                //entity.Property(e => e.Id).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))");

                entity.HasOne(d => d.TiempoPlanDeAhorro)
                        .WithMany(p => p.PlanesDeAhorro)
                        .HasForeignKey(d => d.TiempoPlanDeAhorroId)
                        .HasConstraintName("Ref_PlanesDeAhorro_to_TiempoPlanAhorro");
            });

        }

    }
}
/**
 *  Crear una migracion: add-migration AlgunNombre -context NuevoPlanAhorroContext
 *  Actualizar entidades en la base de datos: Update-Database -context NuevoPlanAhorroContext
 */