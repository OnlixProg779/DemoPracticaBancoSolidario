
using BancoSolidario.Common.CommonExtendEntity;
using Microsoft.EntityFrameworkCore;

namespace BancoSolidario.InfrastructureClient.Persistence
{
    public class BcoSolidarioClientContext : DbContext
    {
        public virtual DbSet<BancoSolidario.Client.Entities.Client>? Clients { get; set; }

        public BcoSolidarioClientContext(DbContextOptions<BcoSolidarioClientContext> options) : base(options)
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
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Spain.1252");

            // ESTO ES FLUENT APIs

            modelBuilder.Entity<BancoSolidario.Client.Entities.Client>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))");
            });

        }

    }
}
