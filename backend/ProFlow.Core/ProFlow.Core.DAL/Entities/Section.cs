using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.DAL.Entities
{
    public class Section : AuditMongoDbEntity
    {
        public string Title { get; set; }
        public ICollection<ObjectId> CardIds { get; set; } = new List<ObjectId>();

        [BsonConstructor]
        public Section(string title) 
        { 
            Title = title;
        }
    }
}
