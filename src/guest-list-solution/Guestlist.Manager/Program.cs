using Guestlist.Core;
using Guestlist.Data;
using Guestlist.Data.Entities;
using Guestlist.UI.Console.Library;
using Guestlist.UI.Console.Library.ConsoleGrid;
using Guestlist.UI.Console.Library.ConsoleMenu;
using Guestlist.UI.Console.Library.ConsoleMenu.MenuItems;
using System;
using System.Collections.Generic;

namespace Guestlist.Manager
{
    class Program
    {
        //By default for a local MongoDB instance connectionString = "mongodb://localhost:27017" 
        static string connectionString = "mongodb://admin:password@192.168.10.200:27017";

        static string dbName = "GuestDatabase";
        static string collectionName = "GuestCollection";

        static void Main(string[] args)
        {
            #region some test for grids
            //IDataProvider<GuestEntity> db = new MongoDbProvider(connectionString, dbName, collectionName);
            //var guestList = db.LoadAllDocuments();

            ////layout settings
            //var layoutSettings = new Dictionary<string, ColumnLayoutConfig>()
            //{                
            //    {"FullName", new ColumnLayoutConfig { Alias = "Name", Width = 20, Visible=true } },
            //    {"Email", new ColumnLayoutConfig { Alias = "Email", Width = 27, Visible=true } },
            //    {"StreetAndNr", new ColumnLayoutConfig { Alias = "Strasse & HNr", Width = 20, Visible=true } },
            //    {"City", new ColumnLayoutConfig { Alias = "Stadt", Width = 15, Visible=true } },
            //    {"PostalCode", new ColumnLayoutConfig { Alias = "Plz", Width = 11, Visible=true } },
            //};

            //var grid = new Grid<GuestEntity>(layoutSettings);
            //grid.DisplayGrid(guestList);

            //Console.WriteLine("\nErmittelte max. Längen für die Spalten:");
            //foreach (var propertyName in config.Properties)
            //{
            //    Console.WriteLine($"{propertyName}:{new string(' ', 12 - propertyName.Length)} {config[propertyName]}");
            //}
            #endregion

            Console.Title = "Guestlist Manager v1.0 - akSoft ©2020";

            //create menu items
            IMenu menu = new Menu();
            menu.Add(new MenuItem("Gäste laden", 'l', LoadGuests));
            menu.Add(new MenuItem("Gäste erfassen", 'n', GetNewGuest));
            menu.Add(new EmptyItem());
            menu.Add(new MenuItem("Bildschirm löschen", 'c', ClearScreen));
            menu.Add(new ColoredMenuItem("Gäste löschen", 'd', ConsoleColor.Red, RemoveGuest));
            
            //start selection            
            while (true)
            {
                Console.WriteLine("\nAuswahlmenü:");
                Console.WriteLine("================\n");

                //show available menu items
                menu.Display(35);

                var selectedAction = menu.SelectItem("\nBitte treffen Sie Ihre Wahl", ConsoleKey.Escape);
                if (selectedAction != null)
                {
                    Console.Clear();
                    selectedAction.ExecuteOnSelection();
                }
                else
                {
                    break;
                }
            }
        }

        private static void ClearScreen()
        {
            Console.Clear();
        }
       
        private static void GetNewGuest()
        {
            var guest = new GuestEntity();

            Console.WriteLine("\n Geben Sie nun die Daten für den neuen Gast ein: \n");

            guest.FullName = ConsoleTools.GetString("Name:  ");
            guest.Email = ConsoleTools.GetString("EMail: ");
            guest.StreetAndNr = ConsoleTools.GetString("Adresse: ");
            guest.PostalCode = ConsoleTools.GetInt("Plz:   ");
            guest.City = ConsoleTools.GetString("Ort:   ");
            guest.LastChangeAt = DateTime.UtcNow;

            IDataProvider<GuestEntity> db = new MongoDbProvider(connectionString, dbName, collectionName);
            db.InsertDocument(guest);
        }

        private static void RemoveGuest()
        {
            //display all guest entries
            LoadGuests();

            Console.Write("\nGeben Sie die zu löschende Gäste-ID ein (LEER für Abbruch): ");
            var id = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(id))
            {
                //open db and delete entry
                IDataProvider<GuestEntity> db = new MongoDbProvider(connectionString, dbName, collectionName);
                db.DeleteDocument(Guid.Parse(id));
                Console.WriteLine($"Id {id} gelöscht.");
            }
        }

        private static void LoadGuests()
        {
            //load data from db
            IDataProvider<GuestEntity> db = new MongoDbProvider(connectionString, dbName, collectionName);
            var guestList = db.LoadAllDocuments();

            //dispaly same grid with auto settings parser
            var config = new ColumnLayoutParser<GuestEntity>();
            var settings = config.ParseLayoutSettings(guestList);

            var grid = new Grid<GuestEntity>(settings);
            grid.DisplayGrid(guestList);
        }
    }
}
