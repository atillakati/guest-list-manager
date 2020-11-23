using System;
using System.Collections.Generic;
using System.Text;

namespace Guestlist.UI.Console.Library.ConsoleMenu.MenuItems
{
    public class MenuItem : IMenuItem
    {
        private string _description;
        private char _code;
        private int _order;
        private Action<MenuItemSelectedArgs> _executeOnSelection;


        public MenuItem(string description, char code, Action<MenuItemSelectedArgs> executeOnSelection)
        {
            _order = -1;

            _description = description;
            _code = code;
            _executeOnSelection = executeOnSelection;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public char Code => _code;

        public int Order
        {
            get => _order;
            set => _order = value;
        }
        public Action<MenuItemSelectedArgs> ExecuteOnSelection 
        {
            get => _executeOnSelection;
            set => _executeOnSelection = value;
        }

        public virtual void Display(int width)
        {
            System.Console.WriteLine("[{0}]{1}{2}", _code, new string('.', width - _description.Length), _description);
        }    
    }
}
