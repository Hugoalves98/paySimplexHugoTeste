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
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IMeetingService, MeetingService>();

            //Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();        
            services.AddScoped<IProjectRepository, ProjectRepository>();        
            services.AddScoped<IMeetingRepository, MeetingRepository>();        
        }
    }
}