using MongoDB.Bson;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.DAL.Entities
{
    public class ChecklistItem
    {
        public bool IsChecked { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
