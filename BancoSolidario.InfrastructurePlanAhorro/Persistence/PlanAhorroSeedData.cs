using BancoSolidario.NuevoPlanAhorro.Entities;
using Microsoft.Extensions.Logging;

namespace BancoSolidario.InfrastructurePlanAhorro.Persistence
{
    public class PlanAhorroSeedData
    {
        public static async Task SeedAsync(NuevoPlanAhorroContext _context, ILoggerFactory loggerFactory)
        {

            if (!_context.TiemposParaPlanDeAhorro!.Any())
            {
                var logger = loggerFactory.CreateLogger<PlanAhorroSeedData>();

                var entity = new TiempoPlanDeAhorro()
                {
                    Id = Guid.NewGuid().ToString(),
                    Meses = 12,
                    TasaDeInteresAnual = 3,
                    TipoDeInteres = "NOMINAL",
                };

               _context.TiemposParaPlanDeAhorro!.Add(entity);


               var respon =  await _context.SaveChangesAsync();

                logger.LogInformation($"Insertando nuevos records ({respon}) a la entidad {nameof(TiempoPlanDeAhorro)}");

            }
         
     

        }
    }
}
