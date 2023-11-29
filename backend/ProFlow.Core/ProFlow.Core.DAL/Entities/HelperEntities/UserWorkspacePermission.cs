using ProFlow.Core.DAL.Entities.Enums;

namespace ProFlow.Core.DAL.Entities.HelperEntities
{
    public class UserWorkspacePermission
    {
        public long UserId { get; set; }
        public long WorkspaceId { get; set; }
        public Permissions Permission { get; set; }
        public Workspace? Workspace { get; set; }
    }
}
