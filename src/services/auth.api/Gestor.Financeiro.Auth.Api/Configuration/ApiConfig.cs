using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gestor.Financeiro.Auth.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}", true, true)
            .AddEnvironmentVariables();

            if (builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();


            return services;
        }

    }
}