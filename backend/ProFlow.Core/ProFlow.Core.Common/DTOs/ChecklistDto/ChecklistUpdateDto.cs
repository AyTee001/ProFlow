using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.Common.DTOs.ChecklistDto
{
    public class ChecklistUpdateDto : MongoDbEntity
    {
        public string? Title { get; set; }
        public ICollection<ChecklistItem> ListItems { get; set; } = new List<ChecklistItem>();

    }
}
