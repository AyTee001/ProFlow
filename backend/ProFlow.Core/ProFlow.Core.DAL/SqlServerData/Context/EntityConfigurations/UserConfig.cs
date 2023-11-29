using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProFlow.Core.DAL.Entities;

namespace ProFlow.Core.DAL.SqlServerData.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.WorkspacePermissions)
                .WithOne()
                .HasForeignKey(e => e.UserId);
        }
    }
}
