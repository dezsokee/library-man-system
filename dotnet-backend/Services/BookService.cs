using webapi;
using webapi.Exceptions;

public class BookService : IBookService {
    private readonly IBookRepository _repository;

    public BookService(IBookRepository bookRepository)
    {
        _repository = bookRepository;
    }

    public async Task<List<Book>> GetAll() {
        return await _repository.GetAllAsync();
    }

    public async Task<Book> GetBookById(int id) {
        var book = await _repository.GetByIdAsync(id);

        if(book != null) {
            return book;
        }

        throw new BookNotFoundException($"There is no book with id {id}");
    }

    public async Task<Book> AddBook(Book newBook) {
        return await _repository.CreateAsync(newBook);
    }

    public async Task<Book> UpdateBook(int id, Book updateBookFromBody) {
        return await _repository.UpdateAsync(id, updateBookFromBody);
    }

    public async Task DeleteBook(int id) {
        await _repository.DeleteBookByIdAsync(id);
    }

    public async Task InsertSecondVersionOfBooks(List<int> ids) {
        foreach (int id in ids) {
            Book? book = await _repository.GetByIdAsync(id);
            
            if (book != null) {
                book.Title += " 2.0";
                await _repository.UpdateAsync(id, book);
            }
        }
    }

}