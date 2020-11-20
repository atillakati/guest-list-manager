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

            IDataProvider<GuestEntity> db = new MongoDbProvider(connectionString, dbName, collectionName);            
            var guestList = db.LoadAllDocuments();

            //layout settings
            var layoutSettings = new Dictionary<string, ColumnLayoutConfig>()
            {                
                {"FullName", new ColumnLayoutConfig { Alias = "Name", Width = 20, Visible=true } },
                {"Email", new ColumnLayoutConfig { Alias = "Email", Width = 27, Visible=true } },
                {"StreetAndNr", new ColumnLayoutConfig { Alias = "Street & Nr", Width = 20, Visible=true } },
                {"City", new ColumnLayoutConfig { Alias = "City", Width = 15, Visible=true } },
                {"PostalCode", new ColumnLayoutConfig { Alias = "PostalCode", Width = 11, Visible=true } },
            };

            var grid = new Grid<GuestEntity>(layoutSettings);
            grid.DisplayGrid(guestList);
        }
    }
}
