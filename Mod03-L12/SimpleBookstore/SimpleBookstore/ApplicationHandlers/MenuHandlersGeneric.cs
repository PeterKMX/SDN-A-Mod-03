using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBookstore.ApplicationMenu;
using SimpleBookstore.ApplicationView;
using SimpleBookstore.DomainEntities;
using SimpleBookstore.DomainServices;

namespace SimpleBookstore.Controllers
{
  public class MenuHandlersGeneric
  {
    ItemsServiceGeneric<Book> _itemServiceB;
    ItemsServiceGeneric<JournalIssue> _itemServiceJ;
    VMBookActions _vmBookActions;
    VMJournalActions _vmJournalActions;

    //-------------------------------------------------------
    public MenuHandlersGeneric(
      ItemsServiceGeneric<Book> itemServiceB,
      ItemsServiceGeneric<JournalIssue> itemServiceJ)
    {
      _itemServiceB = itemServiceB;
      _itemServiceJ = itemServiceJ;
      _vmBookActions = new VMBookActions();
      _vmJournalActions = new VMJournalActions();
    }
    //------------------------------------------------------------
    public void OnUserAction(MenuActionTypes userActionType)
    {
      switch (userActionType)
      {
        case MenuActionTypes.AddBook:
          OnAddBook();
          break;
        case MenuActionTypes.ReadDetails:
          OnReadBookDetails();
          break;
        case MenuActionTypes.EditBook:
          OnEditBook();
          break;
        case MenuActionTypes.RemoveBook:
          OnDeleteBook();
          break;
        case MenuActionTypes.ReadBooksList:
          OnShowBooksList();
          break;
        case MenuActionTypes.AutogenBooksList:
          OnAutogenBooksList();
          break;
        case MenuActionTypes.AddJournal:
          OnAddJournal();
          break;
        case MenuActionTypes.ReadDetailsJournal:
          OnReadJournalDetails();
          break;
        case MenuActionTypes.EditJournal:
          OnEditBook();
          break;
        case MenuActionTypes.RemoveJournal:
          OnDeleteJournal();
          break;
        case MenuActionTypes.ReadJournalList:
          OnShowJournalList();
          break;
        case MenuActionTypes.AutogenJournalList:
          OnAutogenJournalList();
          break;

        default:
          throw new Exception("Error: unknown book action");
      }
    }
    //================================================================
    // Book item handlers
    //--------------------------------------------------------------
    private void OnAddBook()
    {
      //Book newBook = _vmBook.CreateBook();
      //_bookService.AddBook(newBook);

      Book newBook = _vmBookActions.Create();
      _itemServiceB.Add(newBook);
    }
    //-------------------------------------------------------------
    private void OnReadBookDetails()
    {

      if (_itemServiceB.ItemListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }

      List<int> validIds = _itemServiceB.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      Book book = _itemServiceB.Read(id);
      _vmBookActions.Show(book);
    }
    //--------------------------------------------------------------
    private void OnEditBook()
    {
      List<int> validIds = _itemServiceB.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      Book book = _itemServiceB.Read(id);

      Book bookUpdate = _vmBookActions.Edit(book);
      _itemServiceB.Update(id, bookUpdate);
    }
    //----------------------------------------------------------------
    private void OnDeleteBook()
    {
      if (_itemServiceB.ItemListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }

      List<int> validIds = _itemServiceB.GetIdList();
      int id = _vmBookActions.SelectId(validIds);
      _itemServiceB.Delete(id);

      Console.WriteLine("[DONE]");
    }
    //----------------------------------------------------------
    private void OnShowBooksList()
    {
      //List<Book> books = _bookService.ReadAll();
      //_vmBook.ShowBookList(books);
      List<Book> list = _itemServiceB.ReadAll();
      _vmBookActions.ShowList(list);
    }
    //-------------------------------------------
    private void OnAutogenBooksList()
    {
      Console.WriteLine("[Adding 3 books...]");

      Book book;

      book = new Book();
      book.Title = "The C# Programming Language";
      book.Authors = "Anders Hejlsberg";
      book.Publisher = "Wiley";
      book.Year = 2014;
      _itemServiceB.Add(book);

      book = new Book();
      book.Title = "Beginning gRPC with ASP.NET Core 6";
      book.Authors = "Anthony Giretti";
      book.Publisher = "Apress";
      book.Year = 2022;
      _itemServiceB.Add(book);

      book = new Book();
      book.Title = "Learn PHP 8";
      book.Authors = "Steve Prettyman";
      book.Publisher = "Apress";
      book.Year = 2020;
      _itemServiceB.Add(book);
    }

    //================================================================
    // Journal item handlers
    //--------------------------------------------------------------
    private void OnAddJournal()
    {
      JournalIssue journalIssue = _vmJournalActions.Create();
      _itemServiceJ.Add(journalIssue);
    }
    //-------------------------------------------------------------
    private void OnReadJournalDetails()
    {
      if (_itemServiceJ.ItemListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }

      List<int> validIDs = _itemServiceJ.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      JournalIssue issue = _itemServiceJ.Read(id);
      _vmJournalActions.Show(issue);
    }
    //--------------------------------------------------------------
    private void OnEditJournal()
    {
      if (_itemServiceJ.ItemListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }

      List<int> validIDs = _itemServiceJ.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      JournalIssue issue = _itemServiceJ.Read(id);

      JournalIssue editedIssue = _vmJournalActions.Edit(issue);
      _itemServiceJ.Update(id, editedIssue);
    }
    //----------------------------------------------------------------
    private void OnDeleteJournal()
    {
      if (_itemServiceJ.ItemListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }

      List<int> validIDs = _itemServiceJ.GetIdList();
      int id = _vmJournalActions.SelectId(validIDs);
      _itemServiceJ.Delete(id);

      Console.WriteLine("[DONE]");
    }
    //----------------------------------------------------------
    private void OnShowJournalList()
    {
      List<JournalIssue> issues = _itemServiceJ.ReadAll();
      _vmJournalActions.ShowList(issues);
    }
    //-------------------------------------------
    private void OnAutogenJournalList()
    {
      // we know types here so we implement 
      // autogen for 3 journal issues here
      // and use _itemServiceJ.Add(); 
      JournalIssue issue = null;

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 1;
      _itemServiceJ.Add(issue);

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 2;
      _itemServiceJ.Add(issue);

      issue = new JournalIssue();
      issue.Name = "MSDN Magazine";
      issue.Year = 2019;
      issue.Vol = 34;
      issue.Nr = 3;
      _itemServiceJ.Add(issue);

      Console.WriteLine("[DONE]");
    }
  }
}
