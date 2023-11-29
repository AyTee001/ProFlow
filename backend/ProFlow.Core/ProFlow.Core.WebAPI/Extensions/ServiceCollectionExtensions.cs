using Microsoft.Extensions.Options;
using ProFlow.Core.DAL.MongoDbData.Interfaces;
using ProFlow.Core.DAL.MongoDbData;
using ProFlow.Core.DAL.SqlServerData.Context;
using Microsoft.EntityFrameworkCore;

namespace ProFlow.Core.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProFlowMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProFlowMongoDbSettings>(
                configuration.GetSection(nameof(ProFlowMongoDbSettings)));

            services.AddSingleton<IProFlowMongoDbSettings>(provider =>
                provider.GetRequiredService<IOptions<ProFlowMongoDbSettings>>().Value);

            services.AddSingleton(provider => new ProFlowMongoDbContext(provider.GetRequiredService<IProFlowMongoDbSettings>()));

        }

        public static void AddProFlowSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProFlowSqlContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ProFlowSqlConnection"),
                    opt => opt.MigrationsAssembly(typeof(ProFlowSqlContext).Assembly.GetName().Name)));

        }
    }
}
