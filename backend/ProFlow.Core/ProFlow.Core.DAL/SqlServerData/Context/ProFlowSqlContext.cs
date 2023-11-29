using Microsoft.EntityFrameworkCore;
using ProFlow.Core.DAL.Entities;

namespace ProFlow.Core.DAL.SqlServerData.Context
{
    public class ProFlowSqlContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Workspace> Workspaces => Set<Workspace>();

        public ProFlowSqlContext(DbContextOptions<ProFlowSqlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
        }
    }
}
