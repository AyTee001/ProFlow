using MongoDB.Bson.Serialization.Attributes;
using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Enums;

namespace ProFlow.Core.DAL.Entities
{
    public class Board : AuditMongoDbEntity
    {
        public BoardType BoardType { get; set; }
        public string Title { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();

        [BsonConstructor]
        public Board(string title) 
        { 
            Title = title;
        }
    }
}
