using MongoDB.Bson;

namespace ProFlow.Core.DAL.Entities.HelperEntities
{
    public class DeleteInfo
    {
        public string? Id { get; set; }
        public int Version { get; set; }
    }
}
