using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleGrid
{
    public class ColumnLayoutParser<T>
    {
        private Dictionary<string, int> _maxColumnLength;
        private PropertyInfo[] _properties;

        public ColumnLayoutParser()
        {
            _maxColumnLength = new Dictionary<string, int>();
            _properties = new PropertyInfo[0];
        }

        /// <summary>
        /// The list of available properties for type T
        /// </summary>
        public IEnumerable<string> Properties
        {
            get
            {
                return _properties.ToList().Select(x => x.Name);
            }
        }

        /// <summary>
        /// Returns the parsed max column length for the property with the name in propertyName
        /// </summary>
        /// <param name="propertyName">The property name the length looked for</param>
        /// <returns></returns>
        public int this[string propertyName]
        {
            get { return _maxColumnLength[propertyName]; }
        }


        /// <summary>
        /// Parses the necessary column layout settings for provided data list of type T
        /// </summary>
        /// <param name="gridData">The data list to parse the settings for</param>
        /// <returns></returns>
        public Dictionary<string, ColumnLayoutConfig> ParseLayoutSettings(IEnumerable<T> gridData)
        {
            var typeInfo = typeof(T);

            //get available properties
            _properties = typeInfo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //determin the max. length of values
            _maxColumnLength = GetMaxLengthOfProperties(gridData, _properties);

            //create settings
            var layoutSettings = CreateLayoutSettings(_properties, _maxColumnLength);

            return layoutSettings;
        }


        private Dictionary<string, ColumnLayoutConfig> CreateLayoutSettings(IEnumerable<PropertyInfo> properties, Dictionary<string, int> maxColumnLength)
        {
            var layoutSettings = new Dictionary<string, ColumnLayoutConfig>();

            foreach (var property in properties)
            {
                var config = new ColumnLayoutConfig()
                {
                    Alias = property.Name,
                    Width = maxColumnLength[property.Name],
                    Visible = true
                };

                layoutSettings.Add(config.Alias, config);
            }

            return layoutSettings;
        }

        private Dictionary<string, int> GetMaxLengthOfProperties(IEnumerable<T> gridData, PropertyInfo[] properties)
        {
            var maxColumnLength = new Dictionary<string, int>();

            foreach (var property in properties)
            {
                if (!maxColumnLength.ContainsKey(property.Name))
                {
                    maxColumnLength.Add(property.Name, property.Name.Length + 2);
                }

                var maxLengthOfValues = GetMaxLengthOfValues(property, gridData);
                if (maxLengthOfValues > maxColumnLength[property.Name])
                {
                    maxColumnLength[property.Name] = maxLengthOfValues;
                }
            }

            return maxColumnLength;
        }

        private int GetMaxLengthOfValues(PropertyInfo property, IEnumerable<T> gridData)
        {
            List<int> lengthList = new List<int>();

            foreach (var item in gridData)
            {
                var value = property.GetValue(item);
                lengthList.Add(value.ToString().Length + 2);
            }

            return lengthList.Max();
        }
    }
}
