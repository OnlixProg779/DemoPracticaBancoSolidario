using BancoSolidario.ApplicationClient.Contracts.Persistence;
using BancoSolidario.ApplicationClient.Contracts.Persistence.Repositories;
using BancoSolidario.InfrastructureClient.Persistence;
using BancoSolidario.InfrastructureClient.Repositories;
using BancoSolidario.InfrastructureClient.Repositories.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoSolidario.InfrastructureClient
{
    public static class InfrastructureClientServiceRegistration
    {
        //IConfiguration es para poder tener acceso al archivo JSON de configuracion
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BcoSolidarioClientContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionStringSqlServer"));
            });

            services.AddScoped(typeof(IUnitOfWorkAppClient), typeof(UnitOfWorkAppClient));



            services.AddScoped(typeof(IClientRepository), typeof(ClientRepository));



            services.AddHttpContextAccessor();


            return services;

        }
    }
}
