using AutoMapper;
using Gestor.Financeiro.Domain.Models;
using Gestor.Financeiro.Domain.Models.ViewModels;

namespace Gestor.Financeiro.Web.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void ConfigAutoMapper(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configMapper = new MapperConfiguration(c =>
            {
                c.CreateMap<ContaViewModel, Conta>();
                c.CreateMap<Conta, ContaViewModel>();
                c.CreateMap<TransacaoViewModel, Transacao>();
                c.CreateMap<Transacao, TransacaoViewModel>();
            });

            IMapper mapper = configMapper.CreateMapper();

            builder.Services.AddSingleton(mapper);
        }
    }
}
