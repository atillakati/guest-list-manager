using Guestlist.Core;
using Guestlist.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Guestlist.Data
{
    public class MongoDbProvider : IDataProvider<GuestEntity>
    {
        private readonly IMongoDatabase _db;
        private readonly string _collectionName;

        /// <summary>
        /// Creates an instance of MongoDbProvider to get access to a mongodb
        /// </summary>
        /// <param name="connectionString">By default for a local MongoDB instance connectionString = "mongodb://localhost:27017"</param>
        /// <param name="databaseName">The name of the database to use or create.</param>
        /// <param name="collectionName">The collection name = table name</param>
        public MongoDbProvider(string connectionString, string databaseName, string collectionName)
        {
            _collectionName = collectionName;

            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(databaseName);            
        }

        
        public void InsertDocument(GuestEntity document)
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);
            collection.InsertOne(document);
        }

        public List<GuestEntity> LoadAllDocuments()
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);

            return collection.Find(new BsonDocument()).ToList();
        }

        public GuestEntity LoadDocumentById(Guid id)
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);
            var filter = Builders<GuestEntity>.Filter.Eq("Id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        public void UpdateDocument(Guid id, GuestEntity document)
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);

            var result = collection.ReplaceOne(new BsonDocument("_id", id), document, new ReplaceOptions { IsUpsert = false });
        }

        public void UpsertDocument(Guid id, GuestEntity document)
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);

            var result = collection.ReplaceOne(new BsonDocument("_id", id), document, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteDocument(Guid id)
        {
            var collection = _db.GetCollection<GuestEntity>(_collectionName);

            var filter = Builders<GuestEntity>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
