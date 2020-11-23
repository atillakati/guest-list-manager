using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleMenu
{
    public class Menu
    {
        private List<IMenuItem> _items;

        public Menu()
        {
            _items = new List<IMenuItem>();
        }

        public int Count
        {
            get { return _items.Count; }
        }


        public void Display(int width)
        {
            foreach (var item in _items)
            {
                item.Display(width);
            }
        }

        /// <summary>
        /// Returns the selected IMenuItem type. null if selection was canceled by cancel-key.
        /// </summary>
        /// <param name="userPrompt">The user prompt to display</param>
        /// <param name="cancelKey">The key which cancels the selection process</param>
        /// <returns></returns>
        public IMenuItem SelectItem(string userPrompt, ConsoleKey cancelKey)
        {
            ConsoleKeyInfo input;

            do
            {
                System.Console.Write($"{userPrompt} (Cancel with {cancelKey}): ");
                input = System.Console.ReadKey(true);

                foreach (var item in _items)
                {
                    if(item.Code == input.KeyChar)
                    {
                        return item;
                    }
                }
            }
            while (input.Key != cancelKey);

            return null;
        }

        public void Add(IMenuItem menuItem)
        {
            _items.Add(menuItem);
        }

        public void Remove(IMenuItem menuItem)
        {
            _items.Remove(menuItem);
        }
    }
}
