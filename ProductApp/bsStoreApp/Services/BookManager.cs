using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookManager(IRepositoryManager manager)
        {
            _manager = manager;
        }


        public Book CreateOneBook(Book book)
        {
            if(book is null)
            throw new ArgumentNullException(nameof(book));

            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if(entity is null)
            throw new Exception($"Book with id:{id} could not found");

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChnages)
        {
            return _manager.Book.GetAllBooks(trackChnages);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id,trackChanges);
        }

        public void UpdateOneBook(int id, Book book)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if(entity is null)
            throw new Exception($"Book with id:{id} could not found");

            if(book is null)
            throw new ArgumentException(nameof(book));

            entity.Title = book.Title;
            entity.Price = book.Price;

            _manager.Book.Update(entity);
            _manager.Save();
        }

    }
}