using Guestlist.Core;
using System;
using System.Collections.Generic;

namespace Guestlist.Data
{
    public class MonogoDbProvider : IDataProvider<Guest>
    {
        public void DeleteDocument(string collectionName, Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertDocument(string collectionName, Guest document)
        {
            throw new NotImplementedException();
        }

        public List<Guest> LoadAllDocuments(string collectionName)
        {
            throw new NotImplementedException();
        }

        public Guest LoadDocumentById(string collectionName, Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(string collectionName, Guid id, Guest document)
        {
            throw new NotImplementedException();
        }

        public void UpsertDocument(string collectionName, Guid id, Guest document)
        {
            throw new NotImplementedException();
        }
    }
}
