using System.Collections.Generic;
using System.Threading.Tasks;
using webapi;

public interface IBookRepository
{
    public Task<List<Book>> GetAllAsync();

    public Task<Book?> GetByIdAsync(int id);

    public Task<Book> CreateAsync(Book book);

    public Task<Book> UpdateAsync(int id, Book book);

    public Task DeleteBookByIdAsync(int id);
}
