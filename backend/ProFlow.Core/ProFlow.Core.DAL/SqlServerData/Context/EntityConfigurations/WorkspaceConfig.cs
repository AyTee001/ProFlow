using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProFlow.Core.DAL.Entities;

namespace ProFlow.Core.DAL.SqlServerData.Context.EntityConfigurations
{
    internal class WorkspaceConfig : IEntityTypeConfiguration<Workspace>
    {
        public void Configure(EntityTypeBuilder<Workspace> builder)
        {
            builder.HasMany(e => e.Tags)
                .WithOne()
                .HasForeignKey(e => e.WorkspaceId);
        }
    }
}
