using Microsoft.EntityFrameworkCore;
using ProFlow.Core.DAL.SqlServerData.EntityConfigurations;

namespace ProFlow.Core.DAL.SqlServerData.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }
    }
}
