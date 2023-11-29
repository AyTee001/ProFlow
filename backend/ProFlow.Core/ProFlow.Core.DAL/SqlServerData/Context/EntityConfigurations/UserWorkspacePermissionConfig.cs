using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProFlow.Core.DAL.Entities.HelperEntities
{
    public class UserWorkspacePermissionConfig : IEntityTypeConfiguration<UserWorkspacePermission>
    {
        public void Configure(EntityTypeBuilder<UserWorkspacePermission> builder)
        {
            builder.HasKey(e => new {e.UserId, e.WorkspaceId});

            builder.HasOne(e => e.Workspace)
                .WithMany()
                .HasForeignKey(e => e.WorkspaceId);
        }
    }
}
