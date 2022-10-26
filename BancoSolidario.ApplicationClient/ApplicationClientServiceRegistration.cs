
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BancoSolidario.ApplicationClient
{
    public static class ApplicationClientServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());// Automaticamente va a leer todas las clases q esten heredando las interfaces del mediatR

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Automaticamente va a leer todas las clases q esten heredando las interfaces del automaper y las va a inyectar
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); //Automaticamente va a leer todas las clases q esten referenciando a AbstractValidation y fluentValidation y va a referenciar e inyectar los objetos de validacion creados.

            return services;
        }
    }
}
