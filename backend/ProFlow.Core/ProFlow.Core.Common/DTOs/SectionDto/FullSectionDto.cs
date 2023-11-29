using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.Common.DTOs.SectionDto
{
    public class FullSectionDto : AuditMongoDbEntity
    {
        public string? Title { get; set; }
        public ICollection<Card> Cards { get; set; } = new List<Card>();

    }
}
