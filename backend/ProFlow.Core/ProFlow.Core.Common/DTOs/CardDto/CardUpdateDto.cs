using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Enums;

namespace ProFlow.Core.Common.DTOs.CardDto
{
    public class CardUpdateDto : MongoDbEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime DeadlineAt { get; set; }
        public ICollection<long> TagIds { get; set; } = new List<long>();

    }
}
