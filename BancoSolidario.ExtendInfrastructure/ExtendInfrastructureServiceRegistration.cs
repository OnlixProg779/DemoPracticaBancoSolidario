
using BancoSolidario.ExtendApplication.Contracts.Persistence;
using BancoSolidario.ExtendInfrastructure.Repositories.Generics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BancoSolidario.ExtendInfrastructure
{
    public static class ExtendInfrastructureServiceRegistration
    {
        public static IServiceCollection AddExtendInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            //services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IAlmacenatorFile, AlmacenatorFileServer>();

            //services.AddTransient<IEmailService, EmailService>();
            return services;

        }

    }
}
