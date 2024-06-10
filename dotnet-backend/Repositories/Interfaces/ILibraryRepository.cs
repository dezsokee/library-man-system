using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi;

public interface ILibraryRepository
{
    public Task<List<Library>> GetAllAsync();

    public Task<Library?> GetByIdAsync(int id);

    public Task<Library> CreateAsync(Library library);

    public Task<Library> UpdateAsync(int id, Library library);

    public Task DeleteLibraryByIdAsync(int id);
}
