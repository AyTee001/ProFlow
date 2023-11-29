using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProFlow.Core.DAL.SqlServerData.Context;

namespace ProFlow.Core.WebAPI.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void UseProFlowSqlContext(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            using var context = scope?.ServiceProvider.GetRequiredService<ProFlowSqlContext>();

            context?.Database.Migrate();
        }
    }
}
