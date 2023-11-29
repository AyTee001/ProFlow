using MongoDB.Bson.Serialization.Attributes;
using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Enums;

namespace ProFlow.Core.DAL.Entities
{
    public class Card : AuditMongoDbEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime DeadlineAt { get; set; }
        public ICollection<string> ChecklistIds { get; set; } = new List<string>();
        public ICollection<long> TagIds { get; set; } = new List<long>();

        [BsonConstructor]
        public Card(string title, string description) 
        { 
            Title = title;
            Description = description;
        }
    }
}
