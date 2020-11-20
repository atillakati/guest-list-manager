# How to use

## Setting the layout manually
```csharp
//get data
var guestList = db.LoadAllDocuments();

//layout settings
var layoutSettings = new Dictionary<string, ColumnLayoutConfig>()
{                
    {"FullName", new ColumnLayoutConfig { Alias = "Name", Width = 20, Visible=true } },
    {"Email", new ColumnLayoutConfig { Alias = "Email", Width = 27, Visible=true } },
    {"StreetAndNr", new ColumnLayoutConfig { Alias = "Strasse & HNr", Width = 20, Visible=true } },
    {"City", new ColumnLayoutConfig { Alias = "Stadt", Width = 15, Visible=true } },
    {"PostalCode", new ColumnLayoutConfig { Alias = "Plz", Width = 11, Visible=true } },
};

//create grid & display
var grid = new Grid<GuestEntity>(layoutSettings);
grid.DisplayGrid(guestList);
```
## Automatic layout settings
```csharp
//get data
var guestList = db.LoadAllDocuments();

//create instance and parse for layout setting
ColumnLayoutParser<GuestEntity> config = new ColumnLayoutParser<GuestEntity>();
var settings = config.ParseLayoutSettings(guestList);            

//create grid & display
grid = new Grid<GuestEntity>(settings);
grid.DisplayGrid(guestList);
```
