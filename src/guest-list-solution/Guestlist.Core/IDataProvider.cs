using System;
using System.Collections.Generic;

namespace Guestlist.Core
{
    /// <summary>
    /// Interface for data provider, access to database
    /// </summary>
    /// <typeparam name="T">Document data type</typeparam>
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Insert new document into collection
        /// </summary>        
        /// <param name="document">The document to create</param>
        void InsertDocument(T document);

        /// <summary>
        /// Load all documents in collection
        /// </summary>
        /// <returns></returns>
        List<T> LoadAllDocuments();

        /// <summary>
        /// Load document by Id
        /// </summary>
        /// <param name="id">The document with the id to load</param>
        /// <returns></returns>
        T LoadDocumentById(Guid id);

        /// <summary>
        /// Update document
        /// </summary>
        /// <param name="id">The document with the id to update</param>
        /// <param name="document"></param>
        void UpdateDocument(Guid id, T document);

        /// <summary>
        /// Insert document into collection if it does not already exist, or update it if it does
        /// </summary>
        /// <param name="id"></param>
        /// <param name="document"></param>
        void UpsertDocument(Guid id, T document);

        /// <summary>
        /// Delete document by Id
        /// </summary>
        /// <param name="id">The document with the id to delete</param>
        void DeleteDocument(Guid id);
    }
}
