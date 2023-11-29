using MongoDB.Bson.Serialization.Attributes;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.DAL.Entities
{
    public class Checklist : AuditMongoDbEntity
    {
        public string Title { get; set; }
        public ICollection<ChecklistItem> ListItems { get; set; } = new List<ChecklistItem>();

        [BsonConstructor]
        public Checklist(string title) 
        { 
            Title = title;
        }
    }
}
