using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBookstore.DomainEntities;

namespace SimpleBookstore.View
{
    public class ViewModelBook
  {
    //--------------------------------------------------
    public ViewModelBook() { }

    //-------------------------------------------------------
    public void ShowBookList(List<Book> booksList)
    {
      Console.WriteLine("-----------------------");
      Console.WriteLine("Showing books list");
      Console.WriteLine("-----------------------");

      if (booksList != null)
      {
        if (booksList.Count == 0)
        {
          Console.WriteLine("[Books list is empty]");
        }
        else
        {
          string bookView = "";
          foreach (Book book in booksList)
          {
            ShowBook(book);
          }
        }
        Console.WriteLine("-----------------------");
      }
    }
    //---------------------------------------------------------
    public void ShowBook(Book book)
    {
      string bookView = "";

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("Title: " + book.Title);
      sb.AppendLine("Authors: " + book.Authors);
      sb.AppendLine("Publisher: " + book.Publisher);
      sb.AppendLine("Year: " + book.Year);
      sb.AppendLine("Id: " + book.Id);

      bookView = sb.ToString();
      Console.WriteLine(bookView);
      return;
    }
    //-------------------------------------------------------------
    public int RequestBookID(List<int> idReferenceList)
    {
      // request a valid book id via console 
      // the list idReferenceList is used to check user reply
      string commandText = "Enter Book Id:";
      Console.WriteLine(commandText);
      return ReplyWithBookID(commandText, idReferenceList);
    }
    //------------------------------------------------------------------
    private int ReplyWithBookID(String commandText, List<int> validIdList)
    {
      bool error = false;
      int errCount = 0;
      int number = 0;

      string tmp = Console.ReadLine();
      error = !int.TryParse(tmp, out number);
      if (!error)
      {
        error = !validIdList.Contains(number);
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
          error = !validIdList.Contains(number);
        }
      }
      return number; 
    }
    //================================================================
    // This is the functionality a visual input form for a book
    //----------------------------------------------------------------
    public Book CreateBook() 
    { 
      Book book = new Book();
      book.Title = this.GetTitle();
      book.Authors = this.GetAuthors();
      book.Publisher = this.GetPublisher();
      book.Year = this.GetYear();     
    
      return book;  
    }
    //-----------------------------------------
    public  string GetTitle()
    {
      Console.WriteLine("Enter book title:");
      return Console.ReadLine();
    }
    //-----------------------------------------
    public  string GetAuthors()
    {
      Console.WriteLine("Enter authors:");
      return Console.ReadLine();
    }
    //-------------------------------------------
    public  string GetPublisher()
    {
      Console.WriteLine("Enter publisher:");
      return Console.ReadLine();
    }
    //-----------------------------------------
    public  int GetYear()
    {
      Console.WriteLine("Enter year of publication (from 1900 until next year):");
      string tmp = Console.ReadLine();
      int year = 0;
      bool hasError = !int.TryParse(tmp, out year);
      if (year < 1900 || year > DateTime.Now.Year + 1)
      {
        hasError = true;
      }
      int errorCount = 0;
      while (hasError)
      {
        errorCount++;
        if (errorCount >= 3)
        {
          Console.WriteLine("Too many errors on input, skipping this question ...");
          break;
        }
        Console.WriteLine("Inorrect input, please enter your age:");
        tmp = Console.ReadLine();
        hasError = !int.TryParse(tmp, out year);
        if (year < 0)
        {
          hasError = true;
        }
      }
      return year;
    }

    //================================================================
    // This is the functionality of a visual edit form for a book
    //----------------------------------------------------------------
    public Book EditBook(Book currentBook)
    {
      Book editedBook = new Book();
      editedBook.Title = EditTitle(currentBook.Title);
      editedBook.Authors = EditAuthors(currentBook.Authors);
      editedBook.Publisher = EditPublisher(currentBook.Publisher);
      editedBook.Year = EditYear(currentBook.Year);
      editedBook.Id = currentBook.Id;

      return editedBook;
    }
    //----------------------------------------------------------
    internal string EditTitle(string title)
    {
      Console.WriteLine("Current Title:");
      Console.WriteLine(title);
      return GetTitle();
    }
    //-------------------------------------------------
    internal string EditAuthors(string authors)
    {
      Console.WriteLine("Current Authors:");
      Console.WriteLine(authors);
      return GetAuthors();
    }
    //-----------------------------------------------------
    internal string EditPublisher(string publisher)
    {
      Console.WriteLine("Current Publisher:");
      Console.WriteLine(publisher);
      return GetPublisher();
    }
    //-------------------------------------------
    internal int EditYear(int year)
    {
      Console.WriteLine("Current year of publication");
      Console.WriteLine(year);
      return GetYear();
    }
  }
}
