using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HFC.Persistence.Repositories;
using HFC.Application.Contracts.Persistence;

namespace HFC.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HFCDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("HFCConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }

    }
}