using ProFlow.Core.DAL.MongoDbData.Interfaces;

namespace ProFlow.Core.DAL.MongoDbData
{
    public class ProFlowMongoDbSettings : IProFlowMongoDbSettings
    {
        public string BoardCollectionName { get; set; } = string.Empty;
        public string CardCollectionName { get; set; } = string.Empty;
        public string ChecklistCollectionName { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
