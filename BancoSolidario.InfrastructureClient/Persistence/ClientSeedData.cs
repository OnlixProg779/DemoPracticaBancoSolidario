using Microsoft.Extensions.Logging;

namespace BancoSolidario.InfrastructureClient.Persistence
{
    public class ClientSeedData
    {
        public static async Task SeedAsync(BcoSolidarioClientContext _context, ILoggerFactory loggerFactory)
        {
            if (!_context.Clients!.Any())
            {
                var logger = loggerFactory.CreateLogger<ClientSeedData>();

                var entity = new BancoSolidario.Client.Entities.Client()
                {
                    Nombre = "Roberto Carlos",
                    Cedula = "1104503344"
                };

               _context.Clients!.Add(entity);


                await _context.SaveChangesAsync();

                logger.LogInformation($"Insertando nuevos records a la entidad {nameof(BancoSolidario.Client.Entities.Client)}");

            }
         
        }
    }
}
