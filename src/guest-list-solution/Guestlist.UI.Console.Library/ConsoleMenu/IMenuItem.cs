using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleMenu
{
    /// <summary>
    /// Simple interface for defineing a menu item struct on console
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// The description to the user about the menu item
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The selection code og the menu item
        /// </summary>
        char Code { get; }

        /// <summary>
        /// The display order of the menu item, default is -1
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// The action which should executed when the menu item is selected
        /// </summary>
        Action<MenuItemSelectedArgs> ExecuteOnSelection { get; set; }

        /// <summary>
        /// Display the menu item on console.
        /// </summary>
        /// <param name="width">The width of the menu item</param>
        void Display(int width);
    }
}
