using Microsoft.Extensions.Logging;

namespace BancoSolidario.InfrastructureClient.Persistence
{
    public class PlanAhorroSeedData
    {
        public static async Task SeedAsync(BcoSolidarioClientContext _context, ILoggerFactory loggerFactory)
        {
            if (!_context.Clients!.Any())
            {
                var logger = loggerFactory.CreateLogger<PlanAhorroSeedData>();

                var entity = new BancoSolidario.Client.Entities.Client()
                {
                    Nombre = "",
                    Cedula = ""
                };

               _context.Clients!.Add(entity);


                await _context.SaveChangesAsync();

                logger.LogInformation($"Insertando nuevos records a la entidad {nameof(BancoSolidario.Client.Entities.Client)}");

            }
         
        }
    }
}
