using SimpleBookstore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookstore.Repository
{
    public interface IRepositoryGeneric<T>
    {
        public void Add(T t);
        public T Read(int Id);
        public List<T> ReadAll();
        public void Update(int Id, T t);
        public void Delete(int Id);
        public List<int> GetIdList();
        public bool ItemListIsEmpty();
        public T FindItemById(int bookId);

    }
}
