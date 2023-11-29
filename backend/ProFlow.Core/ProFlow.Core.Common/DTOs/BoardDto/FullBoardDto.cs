using ProFlow.Core.Common.DTOs.SectionDto;
using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Enums;

namespace ProFlow.Core.Common.DTOs.BoardDto
{
    public class FullBoardDto : AuditMongoDbEntity
    {
        public BoardType BoardType { get; set; }
        public string? Title { get; set; }
        public ICollection<FullSectionDto> Sections { get; set; } = new List<FullSectionDto>();

    }
}
