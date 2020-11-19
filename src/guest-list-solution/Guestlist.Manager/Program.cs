using Guestlist.Core;
using Guestlist.Data;
using Guestlist.Data.Entities;
using Guestlist.UI.Console.Library;
using System;
using System.Collections.Generic;

namespace Guestlist.Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            //By default for a local MongoDB instance connectionString = "mongodb://localhost:27017" 
            string connectionString = "mongodb://admin:password@192.168.10.241:27017";

            string dbName = "GuestDatabase";
            string collectionName = "GuestCollection";

            IDataProvider<GuestEntity> db = new MonogoDbProvider(connectionString, dbName, collectionName);            

            var guestList = db.LoadAllDocuments();

            //layout settings
            var layoutSettings = new Dictionary<string, int>()
            {
                {"Id", 40 },
                {"FullName", 20 },
                {"Email", 27 },
                {"StreetAndNr", 20 },
                {"City", 15 },
                {"PostalCode", 11 },
                {"HasConfirmed", 13 },
                {"LastChangeAt", 25 },
            };

            var grid = new Grid<GuestEntity>(layoutSettings);
            grid.DisplayGrid(guestList);
        }
    }
}
