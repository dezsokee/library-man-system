using Microsoft.AspNetCore.Mvc;
using webapi;
using webapi.Exceptions;

public class LibraryService : ILibraryService {
    private readonly ILibraryRepository _repository;

    public LibraryService(ILibraryRepository libraryRepository)
    {
        _repository = libraryRepository;
    }

    public async Task<List<Library>> GetAll() {
        return await _repository.GetAllAsync();
    }

    public async Task<Library> GetLibraryById(int id) {
        var library = await _repository.GetByIdAsync(id);

        if(library != null) {
            return library;
        }

        throw new LibraryNotFoundException($"There is no library with id {id}");
    }

    public async Task<Library> AddLibrary(Library newLibrary) {
        return await _repository.CreateAsync(newLibrary);
    }

    public async Task<Library> UpdateLibrary(int id, Library updateLibraryFromBody) {
        return await _repository.UpdateAsync(id, updateLibraryFromBody);
    }

    public async Task DeleteLibrary(int id) {
        
        await _repository.DeleteLibraryByIdAsync(id);
    }

    public async Task<Book> SearchBookByKeyword (int libraryId, string keyword) {
        var library = await _repository.GetByIdAsync(libraryId);

        if (library == null)
        {
            throw new LibraryNotFoundException("There is no library with this id");
        }

        if (library.Books == null)
        {
            throw new BookNotFoundException("There are no books in this library");
        }

        var book = library.Books.Find(b => b.Title != null && b.Title.Contains(keyword));

        if (book == null)
        {
            throw new BookNotFoundException("There is no book with this keyword");
        }

        return book;
    }
}