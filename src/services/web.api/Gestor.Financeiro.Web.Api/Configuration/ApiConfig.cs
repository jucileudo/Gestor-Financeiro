﻿
using Gestor.Financeiro.Data.Repository;
using Gestor.Financeiro.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gestor.Financeiro.Web.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}", true, true)
            .AddEnvironmentVariables();
            builder.Services.ConfigAutoMapper(builder);
            builder.Services.AddScoped<IContaRepository, ContaRepository>();
            builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();


            if (builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FullAccess", build => build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            });
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();


            return services;
        }

    }
}