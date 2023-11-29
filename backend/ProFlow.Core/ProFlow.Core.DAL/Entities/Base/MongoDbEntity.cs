using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProFlow.Core.DAL.Entities.Base
{
    public abstract class MongoDbEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int Version { get; set; }
    }
}
