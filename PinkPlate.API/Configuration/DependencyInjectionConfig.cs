using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using PinkPlate.API.Extensions;
using PinkPlate.API.Interfaces;
using PinkPlate.Application.Notificacoes;
using PinkPlate.Application.Notificacoes.Interfaces;
using PinkPlate.Application.Produtos.Interfaces;
using PinkPlate.Application.Produtos.Services;
using PinkPlate.Infrastructure.Context;
using PinkPlate.Infrastructure.Repository.Produtos;
using PinkPlate.Infrastructure.Repository.Produtos.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace PinkPlate.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RNContext>();

            services.AddScoped<AuthenticationService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
