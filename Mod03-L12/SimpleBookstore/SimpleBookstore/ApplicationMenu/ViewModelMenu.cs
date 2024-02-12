using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookstore.ApplicationMenu
{
    public class ViewModelMenu
    {
        private MenuService _menuService;

        //--------------------------------------------------------
        public ViewModelMenu(MenuService menuService)
        {
            _menuService = menuService;
        }
        //-----------------------------------------
        public int SelectMenuItem()
        {
            // show menu items list
            string menuLines = _menuService.ToString();
            Console.Write(menuLines);

            string commandText = "Enter your menu choice:";
            Console.WriteLine(commandText);

            // user types menu choice {1,2,3 ...7}
            return ReplyWithMenuID(commandText);
        }
        //-------------------------------------------------------------------------
        private int ReplyWithMenuID(string commandText)
        {
            List<int> allowedMenuIdList = _menuService.GetExistingMenuIdList();

            bool error = false;
            int errCount = 0;
            int number = 0;

            // read reply
            string tmp = Console.ReadLine();

            // parse
            error = !int.TryParse(tmp, out number);
            if (!error)
            {
                error = !allowedMenuIdList.Contains(number);
            }

            string errMsg = "Too many errors on input...";
            while (error)
            {
                errCount++;
                if (errCount >= 3)
                {
                    throw new Exception(errMsg);
                }

                Console.WriteLine($"Incorrect input ({tmp}) Please correct your input:");
                tmp = Console.ReadLine();

                // parse
                error = !int.TryParse(tmp, out number);
                if (!error)
                {
                    error = !allowedMenuIdList.Contains(number);
                }
            }

            return number;
        }
    }
}
