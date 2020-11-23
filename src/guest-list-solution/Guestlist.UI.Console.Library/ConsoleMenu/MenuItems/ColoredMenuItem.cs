using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleMenu.MenuItems
{
    public class ColoredMenuItem : MenuItem
    {
        private ConsoleColor _itemColor;

        public ColoredMenuItem(string description, char code, ConsoleColor itemColor, Action executeOnSelection)
            :base(description, code, executeOnSelection)
        {
            _itemColor = itemColor;
        }

        public override void Display(int width)
        {
            ConsoleColor oldColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = _itemColor;
            
            base.Display(width);
            
            System.Console.ForegroundColor = oldColor;
        }
    }
}
