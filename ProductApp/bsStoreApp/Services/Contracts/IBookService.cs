using System.Data.Common;

namespace Services.Contracts
{
    public interface IBookService
    {
         IEnumerable<Book> GetAllBooks(bool trackChnages);
         Book GetOneBookById(int id, bool trackChanges);
         Book CreateOneBook(Book book);
         void UpdateOneBook(int id, Book book, bool trackChanges);
         void DeleteOneBook(int id, bool trackChanges);
    }
}