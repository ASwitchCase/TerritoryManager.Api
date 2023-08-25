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
    public class UserRepository : IUserRepository
    {
        private const string DATABASE_NAME = "TerritoryDB";
        private const string COLLECTION_NAME = "users";
        private readonly IMongoCollection<User> UsersCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        public UserRepository(MongoDbSettings settings){
            MongoClient client = new MongoClient(settings.GetConnectionString());
            IMongoDatabase mongoDatabase= client.GetDatabase(DATABASE_NAME);
            UsersCollection = mongoDatabase.GetCollection<User>(COLLECTION_NAME);
        }
        public async Task<User?> CreateAsync(User newUser)
        {
            await UsersCollection.InsertOneAsync(newUser);
            return await Task.FromResult(newUser);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await UsersCollection.Find(new BsonDocument()).ToListAsync();
        }
        
        public async Task<bool> DoesContainAsync(User target){
            var collection = await UsersCollection.Find(new BsonDocument()).ToListAsync();
            return await Task.FromResult(collection.Contains(target));
        }
    }
}