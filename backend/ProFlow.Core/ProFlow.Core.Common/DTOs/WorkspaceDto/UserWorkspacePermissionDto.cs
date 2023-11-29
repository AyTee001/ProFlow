using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Entities.Enums;

namespace ProFlow.Core.Common.DTOs.WorkspaceDto
{
    public class UserWorkspacePermissionDto : AuditSqlServerEntity
    {
        public Permissions Permission { get; set; }
        public WorkspaceFullDto? WorkspaceDto { get; set; }

    }
}
