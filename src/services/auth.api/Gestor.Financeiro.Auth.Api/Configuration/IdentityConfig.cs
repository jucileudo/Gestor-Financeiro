using Gestor.Financeiro.Auth.Identidade;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sythem.Identity.API.Data;

namespace Gestor.Financeiro.Auth.Api.Configuration
{
    public static class IdentityConfig
    {

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, WebApplicationBuilder builder
           )
        {
            
            builder.Services.AddDbContext<AuthContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("TransactionsConnection")));
            builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthContext>().AddDefaultTokenProviders();

            builder.Services.AddJwtConfiguration(builder);


            return services;
        }

        public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}