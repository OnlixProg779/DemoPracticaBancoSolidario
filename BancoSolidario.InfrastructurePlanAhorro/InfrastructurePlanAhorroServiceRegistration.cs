using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence;
using BancoSolidario.ApplicationPlanAhorro.Contracts.Persistence.Repositories;
using BancoSolidario.InfrastructurePlanAhorro.Persistence;
using BancoSolidario.InfrastructurePlanAhorro.Repositories;
using BancoSolidario.InfrastructurePlanAhorro.Repositories.PlanAhorro;
using BancoSolidario.InfrastructurePlanAhorro.Repositories.TiempoPlanDeAhorro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoSolidario.InfrastructurePlanAhorro
{
    public static class InfrastructurePlanAhorroServiceRegistration
    {
        //IConfiguration es para poder tener acceso al archivo JSON de configuracion
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<NuevoPlanAhorroContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("ConnectionStringSqlServer"),
                    x => x.MigrationsAssembly("BancoSolidario.InfrastructurePlanAhorro")
                    );
            });

            services.AddScoped(typeof(IUnitOfWorkAppPlanDeAhorro), typeof(UnitOfWorkAppPlanDeAhorro));


            services.AddScoped(typeof(IPlanAhorroRepository), typeof(PlanAhorroRepository));
            services.AddScoped(typeof(ITiempoPlanDeAhorroRepository), typeof(TiempoPlanDeAhorroRepository));


            services.AddHttpContextAccessor();


            return services;

        }
    }
}
