using BancoSolidario.ApplicationPlanAhorro;
using BancoSolidario.ExtendApplication;
using BancoSolidario.ExtendInfrastructure;
using BancoSolidario.InfrastructurePlanAhorro;
using BancoSolidario.InfrastructurePlanAhorro.Persistence;
using BancoSolidario.NuevoPlanAhorro.API.Helpers;
using BancoSolidario.NuevoPlanAhorro.API.Middleware;
using BancoSolidario.NuevoPlanAhorro.API.RemoteContracts;
using BancoSolidario.NuevoPlanAhorro.API.RemoteServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Demo_BcoSolidario_CuentaAhorro", Version = "v1" });
});

builder.Services.AddExtendInfrastructureServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddExtendApplicationServices();
builder.Services.AddApplicationServices();

builder.Services.AddHttpClient("ClienteBancoSolidario", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:ClienteBancoSolidario"]);
});
builder.Services.AddScoped(typeof(IClientServices), typeof(ClientServices));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     .WithExposedHeaders(new string[] { "X-Pagination", "ETag" })
    );
});

builder.Services.AddHttpCacheHeaders(
            (expirationModelOptions) =>
            {
                expirationModelOptions.MaxAge = 60;
                expirationModelOptions.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
            },
            (validationModelOptions) =>
            {
                validationModelOptions.MustRevalidate = true;
            }
);

builder.Services.AddResponseCaching();
builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true;
    setupAction.CacheProfiles.Add("120SecondsChaceProfile",
       new CacheProfile()
       {
           Duration = 120
       });
    setupAction.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());


}).AddNewtonsoftJson(setupAction => {
    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

}).AddXmlDataContractSerializerFormatters();

builder.Services.Configure<MvcOptions>(config =>
{

    var newtonsoftJsonOutputFormatter = config.OutputFormatters
            .OfType<NewtonsoftJsonOutputFormatter>()?.FirstOrDefault();

    if (newtonsoftJsonOutputFormatter != null)
    {
        newtonsoftJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.bncoSolidario.hateoas+json");

    };

    var xmlOutputFormatter = config.OutputFormatters
    .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

    if (xmlOutputFormatter != null)
    {
        xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.bncoSolidario.hateoas+xml");
    }

});


var app = builder.Build();

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_Demo_BcoSolidario_CuentaAhorro v1"));
}
else
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Un Error ha ocurrido, Intente nuevamente");
        });
    });
}

app.UseHttpCacheHeaders();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var loggerFactory = service.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = service.GetRequiredService<NuevoPlanAhorroContext>();
        await context.Database.MigrateAsync();

        await PlanAhorroSeedData.SeedAsync(context, loggerFactory);

    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Error en migration");
    }
}

app.Run();
