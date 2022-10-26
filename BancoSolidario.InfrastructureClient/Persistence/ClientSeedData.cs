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
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Roberto Carlos",
                    Cedula = "1104503344"
                };

               _context.Clients!.Add(entity);

                var entity2 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Alejandro Magno",
                    Cedula = "0706465637"
                };

                _context.Clients!.Add(entity2);

                var entity3 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Julio Jaramillo",
                    Cedula = "1787654567"
                };

                _context.Clients!.Add(entity3);

                var entity4 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Brad Pitt",
                    Cedula = "0409876787"
                };

                _context.Clients!.Add(entity4);

                var entity5 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Tom Cruise",
                    Cedula = "1109087654"
                };

                _context.Clients!.Add(entity5);

                var entity6 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Bon Jovi",
                    Cedula = "0198982367"
                };

                _context.Clients!.Add(entity6);

                var entity7 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Lebron James",
                    Cedula = "0376789802"
                };

                _context.Clients!.Add(entity7);

                var entity8 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Lenny Kravitz",
                    Cedula = "0708985673"
                };

                _context.Clients!.Add(entity8);

                var entity9 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Michael Jackson",
                    Cedula = "1109783547"
                };

                _context.Clients!.Add(entity9);

                var entity10 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Steven Tyler",
                    Cedula = "1709356578"
                };

                _context.Clients!.Add(entity10);

                var entity11 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "James Hetfield",
                    Cedula = "0405768394"
                };

                _context.Clients!.Add(entity11);

                var entity12 = new BancoSolidario.Client.Entities.Client()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = "Joaquín Sabina",
                    Cedula = "0346765876"
                };

                _context.Clients!.Add(entity12);


               var resp = await _context.SaveChangesAsync();

                logger.LogInformation($"Insertando nuevos records ({resp}) a la entidad {nameof(BancoSolidario.Client.Entities.Client)}");

            }
         
        }
    }
}
