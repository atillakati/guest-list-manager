using Guestlist.Core;
using Guestlist.Data.Entities;
using NUnit.Framework;
using System;

namespace Guestlist.Data.Tests
{
    [TestFixture]
    public class MongoDbProviderTests
    {
        string _connectionString = "mongodb://admin:password@192.168.10.241:27017";

        string _dbName = "GuestDatabase";
        string _collectionName = "GuestCollection";
        
        private IDataProvider<GuestEntity> _fixture;

        [Test]
        [Ignore("Test")]
        public void InsertNewData()
        {            
            _fixture = new MongoDbProvider(_connectionString, _dbName, _collectionName);

            var dummyData = new GuestEntity()
            {
                Id = Guid.NewGuid(),
                FullName = "Gandalf der Weise",
                Email = "gandalf@mittelerde.net",
                City = "Mittelerde",
                PostalCode = 12345,
                StreetAndNr = "Der Gute Weg 42",
                HasConfirmed = true,
                LastChangeAt = DateTime.UtcNow
            };

            _fixture.InsertDocument(dummyData);
        }

        [Test]
        [Ignore("Test")]
        public void DeleteDataById()
        {
            _fixture = new MongoDbProvider(_connectionString, _dbName, _collectionName);

            var data = _fixture.LoadAllDocuments();

            _fixture.DeleteDocument(data[0].Id);
        }
    }
}
