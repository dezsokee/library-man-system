using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Exceptions;
using webapi.Helper;

public class LibraryRepository : ILibraryRepository
{
    private readonly BookContext _context;

    public LibraryRepository(BookContext context){
        _context = context;
    }

    public async Task<List<Library>> GetAllAsync()
    {
        var libraries = await _context.Libraries
            .Include(_ => _.Books)
            .Where(l => l.Flag == false)
            .ToListAsync();

        return libraries
            .Select(Converter.FromLibraryDALToLibrary)
            .ToList();
    }

    public async Task<Library?> GetByIdAsync(int id)
    {
        var library = await _context.Libraries
            .Include(_ => _.Books)
            .Where(l => l.Flag == false)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (library == null)
        {
            throw new LibraryNotFoundException($"There is no library with id {id}");
        }

        return Converter.FromLibraryDALToLibrary(library);
    }

    public async Task<Library> CreateAsync(Library library) {

        _context.Libraries.Add(Converter.FromLibraryToLibraryDAL(library));
        await _context.SaveChangesAsync();

        return library;
    }

    public async Task<Library> UpdateAsync(int id, Library library) {
        var savedLibrary = await _context.Libraries.FindAsync(id);

        if (savedLibrary != null && savedLibrary.Flag == false)
        {
            savedLibrary.Name = library.Name;
            savedLibrary.Address = library.Address;
            savedLibrary.ConstructionYear = library.ConstructionYear;
            savedLibrary.Books = library.Books?.Select(Converter.FromBookToBookDAL).ToList();
        
            await _context.SaveChangesAsync();

            return Converter.FromLibraryDALToLibrary(savedLibrary);
        }

        throw new LibraryNotFoundException($"There is no library with id {id}");
    }

    public async Task DeleteLibraryByIdAsync(int id) {
        var library = _context.Libraries.Include(l => l.Books).SingleOrDefault(l => l.Id == id);

        if (library != null)
        {
            if(library.Books?.Count == 0) {
                _context.Libraries.Remove(library);
            } else {
                 library.Flag = true;
            } 
        }
        
        await _context.SaveChangesAsync();
    }
}