using SimpleBookstore.DomainEntities;
using SimpleBookstore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SimpleBookstore.DomainServices
{
  public class BookService : IBookService
  {
    IRepositoryBooks _repositoryBooks { get; set; }

    //-------------------------------------------------
    public BookService(IRepositoryBooks someRepoBooks) 
    { 
      _repositoryBooks = someRepoBooks;
    }
    //--------------------------------------------------
    public void AddBook(Book book)
    {
      _repositoryBooks.AddBook(book); 
    }
    //--------------------------------------------------
    public Book ReadBook(int Id)
    {
      return _repositoryBooks.ReadBook(Id); ;
    }
    //------------------------------------------------------
    public List<Book> ReadAll()
    {
      return _repositoryBooks.ReadAll(); //this.books;
    }
    //------------------------------------------------------
    public void UpdateBook(int Id, Book editedBook)
    {
      if (_repositoryBooks.DataListIsEmpty())
      {
        Console.WriteLine("[Backend list is empty]");
        return;
      }
      _repositoryBooks.UpdateBook(Id, editedBook);  
    }
    //--------------------------------------------------------
    public void DeleteBook(int id)
    {
      _repositoryBooks.DeleteBook(id);  
    }
    //-----------------------------------------
    public List<int> GetValidBookIds()
    {
      return _repositoryBooks.GetBookIds();
    }
    //---------------------------------------------
    public bool DataListIsEmpty() 
    { 
      return _repositoryBooks.DataListIsEmpty(); 
    }    
    //--------------------------------------------
    internal void AutogenBooksList()
    {
      Console.WriteLine("[Adding 3 books...]");
      // add 3 books to backend
      Book book;

      book = new Book();
      book.Title = "The C# Programming Language";
      book.Authors = "Anders Hejlsberg";
      book.Publisher = "Wiley";
      book.Year = 2014;
      AddBook(book);

      book = new Book();
      book.Title = "Beginning gRPC with ASP.NET Core 6";
      book.Authors = "Anthony Giretti";
      book.Publisher = "Apress";
      book.Year = 2022;
      AddBook(book);

      book = new Book();
      book.Title = "Learn PHP 8";
      book.Authors = "Steve Prettyman";
      book.Publisher = "Apress";
      book.Year = 2020;
      AddBook(book);
    }

    //================================================
    // private internal methods
    //--------------------------------------------
    public Book _FindBookById(int bookId)
    {
      return _repositoryBooks.FindBookById(bookId);  
    }
  }
}
