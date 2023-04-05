﻿using Infra.Entities;
using Infra.Interfaces;
using Infra.Repository;
using Infra.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ConfigurationInjector
{
    public static class NativeInjector
    {
        public static void RegisterService(this IServiceCollection services)
        {
            //Services
            services.AddTransient<ITarefaService, TarefaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            //Repositories
            services.AddScoped<ITarefaRepository, TarefaRepository>();         
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();         
        }
    }
}