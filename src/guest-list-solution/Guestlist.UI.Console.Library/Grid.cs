using ConsoleGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Guestlist.UI.Console.Library
{
    public class Grid<T>
    {
        private GridView _gridView;
        private readonly bool _useDefaultColumnSettings;
        private readonly Dictionary<string, int> _columnLayout;

        public Grid(Dictionary<string, int> columnLayout)
        {
            _useDefaultColumnSettings = columnLayout == null;
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
                if (_useDefaultColumnSettings)
                {
                    _gridView.Columns.Add(property.Name, 15);
                }
                else
                {
                    _gridView.Columns.Add(property.Name, _columnLayout[property.Name]);
                }
            }
        }

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
                    var value = property.GetValue(item);
                    valueList.Add(value);
                }

                //add new row with values
                _gridView.Rows.Add(valueList.ToArray());
            }

            _gridView.WriteToConsole();
        }
    }
}
