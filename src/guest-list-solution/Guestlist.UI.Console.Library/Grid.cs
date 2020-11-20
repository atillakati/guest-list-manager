using ConsoleGridView;
using System.Collections.Generic;
using System.Reflection;

namespace Guestlist.UI.Console.Library
{
    /// <summary>
    /// A GridView wrapper for easy handling
    /// </summary>
    /// <typeparam name="T">Data type to display as a grid</typeparam>
    public class Grid<T>
    {
        private GridView _gridView;
        private bool _userColumnSettingsAreProvided;
        private Dictionary<string, ColumnLayoutConfig> _columnLayout;
        private ColumnLayoutConfig _defaultLayoutSetting;

        /// <summary>
        /// Instantiates a Grid with default layout settings of GridView
        /// </summary>
        public Grid()
        {
            _defaultLayoutSetting = null;

            Init(null);
        }

        public Grid(ColumnLayoutConfig defaultLayoutSetting)
        {
            _defaultLayoutSetting = defaultLayoutSetting;

            Init(null);
        }

        /// <summary>
        /// Instantiates a Grid
        /// </summary>
        /// <param name="columnLayout">Defines the grid column layout, default column layout is invisible</param>
        public Grid(Dictionary<string, ColumnLayoutConfig> columnLayout)
        {
            _defaultLayoutSetting = new ColumnLayoutConfig() { Alias = "", Visible = false, Width = 5 };

            Init(columnLayout);
        }

        public Grid(Dictionary<string, ColumnLayoutConfig> columnLayout, ColumnLayoutConfig defaultLayoutSetting)
        {
            _defaultLayoutSetting = defaultLayoutSetting;
            _defaultLayoutSetting ??= new ColumnLayoutConfig() { Alias = "", Visible = false, Width = 5 };

            Init(columnLayout);
        }

        /// <summary>
        /// Displays the data in the provided list in the console as a grid
        /// </summary>
        /// <param name="dataList">The list with data to display</param>
        public void DisplayGrid(IEnumerable<T> dataList)
        {
            List<object> valueList = new List<object>();

            _gridView.Rows.Clear();
            _gridView.Border = true;
            _gridView.GridLines = GridLines.Both;

            var dataType = typeof(T);
            var propertyList = dataType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in dataList)
            {
                valueList.Clear();

                //get each value from item
                foreach (var property in propertyList)
                {
                    var layoutConfig = _columnLayout.GetValueOrDefault(property.Name, _defaultLayoutSetting);
                    if (layoutConfig.Visible)
                    {
                        var value = property.GetValue(item);
                        valueList.Add(value);
                    }
                }

                //add new row with values
                _gridView.Rows.Add(valueList.ToArray());
            }

            _gridView.WriteToConsole();
        }


        private void Init(Dictionary<string, ColumnLayoutConfig> columnLayout)
        {
            _userColumnSettingsAreProvided = !(columnLayout == null);
            _columnLayout = columnLayout;

            _gridView = new GridView();
            InitDataTable();
        }

        private void InitDataTable()
        {
            var dataType = typeof(T);

            var propertyList = dataType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in propertyList)
            {
                if (!_userColumnSettingsAreProvided)
                {
                    if (_defaultLayoutSetting == null)
                    {
                        _gridView.Columns.Add(property.Name, 15);
                    }
                    else
                    {
                        if (_defaultLayoutSetting.Visible)
                        {
                            _gridView.Columns.Add(property.Name, _defaultLayoutSetting.Width);
                        }
                    }
                }
                else
                {
                    var layoutConfig = _columnLayout.GetValueOrDefault(property.Name);
                    if(layoutConfig == null)
                    {
                        layoutConfig = _defaultLayoutSetting;
                        layoutConfig.Alias = property.Name;
                    }

                    if (layoutConfig.Visible)
                    {
                        _gridView.Columns.Add(layoutConfig.Alias, layoutConfig.Width);
                    }
                }
            }
        }

    }
}
