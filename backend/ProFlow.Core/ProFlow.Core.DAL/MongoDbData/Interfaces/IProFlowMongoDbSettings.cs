namespace ProFlow.Core.DAL.MongoDbData.Interfaces
{
    public interface IProFlowMongoDbSettings
    {
        public string BoardCollectionName { get; set; }
        public string CardCollectionName { get; set; }
        public string ChecklistCollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}
