using System.Reflection;
using SimpleBookstore.ApplicationMenu;
using SimpleBookstore.Controllers;
using SimpleBookstore.Repository;
using SimpleBookstore.DomainEntities;
using SimpleBookstore.DomainServices;

namespace SimpleBookstore
{
  internal class Program
  {
    //----------------------------------------------------------------------------------
    static void Main(string[] args)
    {
      try
      {
        string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        Console.Write($"App: M03-L12 Homework, v.{appVersion}, {DateTime.Now}");
        Console.WriteLine("");
        Console.WriteLine("Welcome to Simple Bookstore application");
        Console.WriteLine("M03-L12 adaptations:");
        Console.WriteLine("-Clean Architecture");
        Console.WriteLine("-Generics");
        Console.WriteLine("-Handles 2 types of items: Book and JournalIssue");
        Console.WriteLine("-Repository interface (in-memory)");
        Console.WriteLine("-Improved consistency of view objects");
        Console.WriteLine("-----------------------------------------------------------");

        // configure item repos
        InMemoryRepoGeneric<Book> repoB = new InMemoryRepoGeneric<Book>();
        InMemoryRepoGeneric<JournalIssue> repoJ = new InMemoryRepoGeneric<JournalIssue>();
        // configure item services
        ItemsServiceGeneric<Book> itemServiceB = new ItemsServiceGeneric<Book>(repoB);
        ItemsServiceGeneric<JournalIssue> itemServiceJ = new ItemsServiceGeneric<JournalIssue>(repoJ);

        MenuService mainMenuService = new MenuService();
        mainMenuService.Configure();
        MenuManager mainMenu = new MenuManager(mainMenuService);

        MenuHandlersGeneric menuHandler = new MenuHandlersGeneric(
            itemServiceB,
            itemServiceJ);

        while (true)
        {
          MenuActionTypes userAction = mainMenu.SelectMenuItem();
          if (userAction == MenuActionTypes.Exit)
          {
            break;
          }
          menuHandler.OnUserAction(userAction);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Application error occurred {ex.ToString()}");
      }
      finally
      {
        Console.WriteLine();
        Console.WriteLine("STOPPING: Press any key to exit ...");
        string s = Console.ReadLine();
      }
    }
  }
}
