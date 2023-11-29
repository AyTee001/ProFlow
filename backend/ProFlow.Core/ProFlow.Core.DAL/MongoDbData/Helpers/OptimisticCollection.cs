using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using ProFlow.Core.DAL.Entities.Base;
using ProFlow.Core.DAL.Entities.HelperEntities;
using ProFlow.Core.DAL.Exceptions;
using System.Data;
using System.Linq.Expressions;

namespace ProFlow.Core.DAL.MongoDbData.Helpers
{
    public sealed class OptimisticCollection<T>
        where T : MongoDbEntity
    {
        private readonly IMongoCollection<T> _collection;

        public OptimisticCollection(IMongoCollection<T> mongoCollection)
        {
            _collection = mongoCollection;
        }

        public async Task<T?> GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq(t => t.Id, id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _collection.Find(x => true).ToListAsync();
        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            Ensure.IsNotNull(filter, nameof(filter));

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            await _collection.InsertOneAsync(obj);
            return obj;
        }

        public async Task AddManyAsync(ICollection<T> collectionToInsert)
        {
            await _collection.InsertManyAsync(collectionToInsert);
        }

        public async Task DeleteOneAsync(DeleteInfo obj)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(x => x.Id, obj.Id)
                    & Builders<T>.Filter.Eq(r => r.Version, obj.Version);

            _ = await _collection.FindOneAndDeleteAsync(filter) ?? throw new PreconditionFailedException(nameof(obj), obj.Id!);
        }
        public async Task DeleteManyNoConcurrencyControlAsync(Expression<Func<T, bool>> filter)
        {
            Ensure.IsNotNull(filter, nameof(filter));

            await _collection.DeleteManyAsync(filter);
        }

        public async Task<T> ReplaceOneAsync(T obj)
        {
            int currentVersion = obj.Version;
            obj.Version++;

            return await _collection.FindOneAndReplaceAsync(
                Builders<T>.Filter.Eq(r => r.Id, obj.Id)
                    & Builders<T>.Filter.Eq(r => r.Version, currentVersion),
                obj,
                new FindOneAndReplaceOptions<T>
                {
                    IsUpsert = false,
                    ReturnDocument = ReturnDocument.After
                })
            ?? throw new PreconditionFailedException(nameof(obj), obj.Id!);
        }

        public async Task UpsertOneAsync(T obj)
        {
            int currentVersion = obj.Version;
            obj.Version++;

            _ = await _collection.FindOneAndReplaceAsync(
                Builders<T>.Filter.Eq(r => r.Id, obj.Id)
                    & Builders<T>.Filter.Eq(r => r.Version, currentVersion),
                obj,
                new FindOneAndReplaceOptions<T>
                {
                    IsUpsert = true,
                    ReturnDocument = ReturnDocument.After
                })
            ?? throw new PreconditionFailedException(nameof(obj), obj.Id!);
        }

        public async Task<T> UpdateOneAsync(MongoDbEntity obj, UpdateDefinition<T> updateDefinition)
        {
            int currentVersion = obj.Version;
            obj.Version++;

            return await _collection.FindOneAndUpdateAsync<T>(
                Builders<T>.Filter.Eq(r => r.Id, obj.Id)
                    & Builders<T>.Filter.Eq(r => r.Version, currentVersion), 
                updateDefinition.Set(e => e.Version, obj.Version),
                new FindOneAndUpdateOptions<T>
                {
                    ReturnDocument = ReturnDocument.After
                })
            ?? throw new PreconditionFailedException(nameof(obj), obj.Id!);
        }
    }
}
