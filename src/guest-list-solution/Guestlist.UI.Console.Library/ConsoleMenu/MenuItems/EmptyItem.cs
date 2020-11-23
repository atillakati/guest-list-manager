using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleMenu.MenuItems
{
    public class EmptyItem : IMenuItem
    {
        private int _order;

        public EmptyItem()
        {
            _order = -1;
        }

        public string Description
        {
            get => "";
            set => value = value;
        }

        public char Code => ' ';

        public int Order
        {
            get => _order;
            set => _order = value;
        }

        public Action ExecuteOnSelection 
        {
            get => null;
            set => value = value;
        }

        public void Display(int width)
        {
            System.Console.WriteLine();
        }
    }
}
