using Microsoft.OpenApi.Models;

namespace Gestor.Financeiro.Auth.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, WebApplicationBuilder builder
          )
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestor Financeiro",
                    Version = "v1",
                    Description = "Esta Api faz parte do sistema de Gestão Financeira criado para estudos de .Net 6",
                    Contact = new OpenApiContact() { Name = "Jucileudo Lima", Email = "juci0310@hotmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });


            return services;
        }
    }
}
