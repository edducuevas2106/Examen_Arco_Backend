using BussinesLayer.Services;
using DataInterfaces.Repository;
using DataInterfaces.Services;
using DataLayer.Communication;
using DataLayer.Repository;
using Logs;
using Microsoft.EntityFrameworkCore;

namespace Examen_dev.Config
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            return services;
        }
        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("localDb");
            services.AddDbContext<EntitiesModel>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddServices();
        }


        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<Logs.ILogger, WindowsEventLogger>();
            services.AddScoped<IMarcasRepository, MarcasRepository>();
            services.AddScoped<IDescripcionRepository, DescripcionRepository>();
            services.AddScoped<IModelosRepository, ModelosRepository>();
            services.AddScoped<ISubMarcaRepository, SubMarcaRepository>();
            services.AddScoped<IImportData, ImportData>();

            services.AddScoped<IVehiculosServices, VehiculosServices>();
        }
    }
}
