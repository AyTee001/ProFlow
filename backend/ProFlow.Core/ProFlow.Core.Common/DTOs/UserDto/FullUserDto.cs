using ProFlow.Core.Common.DTOs.WorkspaceDto;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.Common.DTOs.UserDto
{
    public class FullUserDto : SqlServerEntity
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OAuthToken { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public ICollection<UserWorkspacePermissionDto> WorkspacePermissions { get; set; } = new List<UserWorkspacePermissionDto>();
    }
}
