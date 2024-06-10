using webapi;

public interface IBookService {
    public Task<List<Book>> GetAll();

    public Task<Book> GetBookById(int id);

    public Task<Book> AddBook(Book newBook);

    public Task<Book> UpdateBook(int id, Book updateBookFromBody);

    public Task DeleteBook(int id);

    public Task InsertSecondVersionOfBooks(List<int> ids);
}