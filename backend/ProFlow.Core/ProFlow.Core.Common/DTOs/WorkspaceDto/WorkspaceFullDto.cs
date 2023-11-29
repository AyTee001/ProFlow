using ProFlow.Core.Common.DTOs.BoardDto;
using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.Common.DTOs.WorkspaceDto
{
    public class WorkspaceFullDto : AuditSqlServerEntity
    {
        public string? Title { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<BoardPreviewDto> BoardPreviews { get; set; } = new List<BoardPreviewDto>();

    }
}
