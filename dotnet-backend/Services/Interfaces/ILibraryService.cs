using Microsoft.AspNetCore.Mvc;
using webapi;

public interface ILibraryService {
    public Task<List<Library>> GetAll();

    public Task<Library> GetLibraryById(int id);

    public Task<Library> AddLibrary(Library newLibrary);

    public Task<Library> UpdateLibrary(int id, Library updateLibraryFromBody);

    public Task DeleteLibrary(int id);

    public Task<Book> SearchBookByKeyword (int libraryId, string keyword);
}