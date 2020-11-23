using System;

namespace Guestlist.UI.Console.Library.ConsoleMenu
{
    /// <summary>
    /// Interface to represent a menu
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// The count of the item within the menu
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add neu menu item to the menu
        /// </summary>
        /// <param name="menuItem"></param>
        void Add(IMenuItem menuItem);
        
        /// <summary>
        /// Remove a menu item from menu
        /// </summary>
        /// <param name="menuItem"></param>
        void Remove(IMenuItem menuItem);
        
        /// <summary>
        /// Show the whole menu an screen with the provided width
        /// </summary>
        /// <param name="width">The width of a menu item</param>
        void Display(int width);
        
        /// <summary>
        /// Start the selection process of a menu item. Returns the selected menu item.
        /// </summary>
        /// <param name="userPrompt">The user prompt to display to the user</param>
        /// <param name="cancelKey">The cancel key the abort the selection process</param>
        /// <returns>The selected menu item</returns>
        IMenuItem SelectItem(string userPrompt, ConsoleKey cancelKey);
    }
}