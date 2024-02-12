using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookstore.ApplicationMenu
{
  public class MenuManager
  {
    private MenuService _menuService;
    private ViewModelMenu _vmMainMenu;

    //------------------------------------------------
    private MenuManager() { }

    //----------------------------------------------------
    public MenuManager(MenuService menuService)
    {
      _vmMainMenu = new ViewModelMenu(menuService);
    }
    //------------------------------------------------------
    public MenuActionTypes SelectMenuItem()
    {
      int menuItemID = _vmMainMenu.SelectMenuItem();
      MenuActionTypes actionType = ConvertToActionType(menuItemID);

      return actionType;
    }
    //-------------------------------------------------------------
    private MenuActionTypes ConvertToActionType(int menuId)
    {
      switch (menuId)
      {
        case 11: return MenuActionTypes.AddBook;
        case 12: return MenuActionTypes.ReadDetails;
        case 13: return MenuActionTypes.EditBook;
        case 14: return MenuActionTypes.RemoveBook;
        case 15: return MenuActionTypes.ReadBooksList;
        case 16: return MenuActionTypes.AutogenBooksList;

        case 21: return MenuActionTypes.AddJournal;
        case 22: return MenuActionTypes.ReadDetailsJournal;
        case 23: return MenuActionTypes.EditJournal;
        case 24: return MenuActionTypes.RemoveJournal;
        case 25: return MenuActionTypes.ReadJournalList;
        case 26: return MenuActionTypes.AutogenJournalList;

        case 31: return MenuActionTypes.Exit;
        default: throw new Exception("Unknown menu item Id");
      }
    }
  }
}
