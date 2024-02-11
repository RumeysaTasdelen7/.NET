namespace Services.Contracts
{
    public interface IBookService
    {
         IEnumerable<Book> GetAllBooks(bool trackChnages);
         Book GetOneBookById(int id, bool trackChnages);

    }

}