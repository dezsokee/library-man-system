using System.Data.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using webapi;
using webapi.Exceptions;
using webapi.Helper;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context){
        _context = context;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = _context.Books.AsNoTracking().Select(Converter.FromBookDALToBook);

        return await Task.FromResult(books.ToList());
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return null;
        }

        return Converter.FromBookDALToBook(book);
    }

    public async Task<Book> CreateAsync(Book book) {

        var library = _context.Libraries.FirstOrDefault(l => l.Id == book.LibraryId);
        if (library == null)
        {
            throw new InvalidOperationException("Library with the provided ID does not exist.");
        }

        _context.Books.Add(Converter.FromBookToBookDAL(book));

        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book> UpdateAsync(int id, Book book) {
        var savedBook = await _context.Books.FindAsync(id);

        if (savedBook != null)
        {
            savedBook.Title = book.Title;
            savedBook.Pages = book.Pages;
            savedBook.PublishYear = book.PublishYear;
        
            await _context.SaveChangesAsync();

            return Converter.FromBookDALToBook(savedBook);
        }

        throw new BookNotFoundException($"There is no book with id {id}");
    }

    public async Task DeleteBookByIdAsync(int id) {
        var book = await _context.Books.FindAsync(id);
        
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

}