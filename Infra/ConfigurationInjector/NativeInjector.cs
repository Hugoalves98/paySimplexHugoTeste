using Infra.Entities;
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
            services.AddTransient<IHistoricoTarefaService, HistoricoTarefaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAzureBlobService, AzureBlobService>();

            //Repositories
            services.AddScoped<ITarefaRepository, TarefaRepository>();         
            services.AddScoped<IHistoricoTarefaRepository, HistoricoTarefaRepository>();         
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();         
        }
    }
}