using MongoDB.Driver;
using ProFlow.Core.DAL.Entities;
using ProFlow.Core.DAL.MongoDbData.Helpers;
using ProFlow.Core.DAL.MongoDbData.Interfaces;

namespace ProFlow.Core.DAL.MongoDbData
{
    public class ProFlowMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IProFlowMongoDbSettings _settings;

        public OptimisticCollection<Board> Boards => new (_database.GetCollection<Board>(_settings.BoardCollectionName));
        public OptimisticCollection<Card> Cards => new (_database.GetCollection<Card>(_settings.CardCollectionName));
        public OptimisticCollection<Checklist> Checklists => new (_database.GetCollection<Checklist>(_settings.ChecklistCollectionName));

        public ProFlowMongoDbContext(IProFlowMongoDbSettings settings)
        {
            var client = new MongoClient();
            _settings = settings;
            _database = client.GetDatabase(_settings.DatabaseName);
        }
    }
}
