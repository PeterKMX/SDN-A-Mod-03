using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleBookstore.DomainEntities;

namespace SimpleBookstore.DomainServices
{
  public interface IBookService
  {
    public void AddBook(Book book);
    public Book ReadBook(int Id);
    public List<Book> ReadAll();
    public void UpdateBook(int Id, Book bookupdate);
    public void DeleteBook(int Id);
    public List<int> GetValidBookIds();

  }
}
