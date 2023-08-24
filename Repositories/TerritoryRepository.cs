using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using TerritoryManager.Api.Models;
using TerritoryManager.Api.Settings;

namespace TerritoryManager.Api.Repositories
{
    public class TerritoryRepository : ITerritoryRepository
    {
        private const string DATABASE_NAME = "TerritoryDB";
        private const string COLLECTION_NAME = "territories";
        private readonly IMongoCollection<Territory> territoryCollection;
        private readonly FilterDefinitionBuilder<Territory> filterBuilder = Builders<Territory>.Filter;
        public TerritoryRepository(MongoDbSettings settings){
            MongoClient mongoClient = new MongoClient(settings.GetConnectionString());
            IMongoDatabase db = mongoClient.GetDatabase(DATABASE_NAME);
            territoryCollection = db.GetCollection<Territory>(COLLECTION_NAME);
        }
        public async Task<Territory?> GetAsync(string tid)
        {
            var filter = filterBuilder.Eq(territory => territory.tid,tid);
            return await territoryCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Territory>> GetAllAsync()
        {
            return await territoryCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Territory> UpdateAsync(string tid, TerritoryUpdateDto territory)
        {
            var filter = filterBuilder.Eq(territory => territory.tid,tid);
            var newTerritory = await territoryCollection.Find(filter).SingleOrDefaultAsync();
            newTerritory.publisher = territory.publisher;
            newTerritory.dateAssigned = territory.dateAssigned;

            await territoryCollection.ReplaceOneAsync(filter,newTerritory);
            return await Task.FromResult(newTerritory);
        }
    }
}