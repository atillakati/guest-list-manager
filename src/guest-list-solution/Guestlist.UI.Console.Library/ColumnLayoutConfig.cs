using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library
{
    public class ColumnLayoutConfig
    {
        /// <summary>
        /// The alias name for the column to display
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// The width of the column (count of chars)
        /// </summary>
        public int Width { get; set; }        

        /// <summary>
        /// Defines, wheather the column should be shown or not
        /// </summary>
        public bool Visible { get; set; }
    }
}
