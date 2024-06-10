using Microsoft.AspNetCore.Mvc;
using webapi.Helper;

namespace webapi.Controllers;

[ApiController]

public class LibraryController : ControllerBase {
    private readonly ILibraryService _service;

    public LibraryController (ILibraryService libraryService)
    {
        _service = libraryService;
    }

    [HttpGet]
    [Route("api/v1/libraries")]
    public async Task<ActionResult<IEnumerable<Library>>> GetLibraries() {
        List<Library> DBLibraryList = await _service.GetAll();

        if(DBLibraryList.Count == 0) {
            return NotFound("There are no libraries in the database");
        }

        // var libraryDTOList = new List<OutLibraryDTO>();

        // foreach (Library library in DBLibraryList) {
        //     libraryDTOList.Add(Converter.FromLibraryToOutLibraryDTO(library));
        // }

        return Ok(DBLibraryList);
    }

    [HttpGet]
    [Route("api/v1/libraries/{id}")]
    public async Task<ActionResult<Library>> GetLibraryById(int id) {
        
        if(id < 0) {
            return BadRequest("Invalid id");
        }
        
        var lib = await _service.GetLibraryById(id);
        
        if(lib == null) {
            return NotFound("There is no library with this id");
        }

        var libraryDTO = Converter.FromLibraryToOutLibraryDTO(lib);

        return Ok(libraryDTO);
    }

    [HttpPost]
    [Route("api/v1/addLibrary")]
    public async Task<ActionResult<Library>> AddLibrary(InLibraryDTO newLibrary) {
        if(newLibrary == null) {
            return BadRequest("Invalid library data");
        }

        if(newLibrary.ConstructionYear < 0) {
            return BadRequest("The construction year attribute can not be negative");
        }

        var newLibrary2 = Converter.FromInLibraryDTOToLibrary(newLibrary);

        await _service.AddLibrary(newLibrary2);

        var responeOutLibraryDTO = Converter.FromLibraryToOutLibraryDTO(newLibrary2);

        return Created("", responeOutLibraryDTO);
    }

    [HttpPut]
    [Route("api/v1/updateLibrary/{id}")]
    public async Task<ActionResult<Library>> UpdateLibrary(int id, InLibraryDTO updateLibraryFromBody) {
        
        if(id < 0) {
            return BadRequest("Invalid id");
        }

        if(updateLibraryFromBody == null) {
            return BadRequest("Invalid library data");
        }

        if(updateLibraryFromBody.ConstructionYear < 0) {
            return BadRequest("The construction year attribute can not be negative");
        }

        var coreUpdateLibrary = Converter.FromInLibraryDTOToLibrary(updateLibraryFromBody);

        await _service.UpdateLibrary(id, coreUpdateLibrary);

        var responseOutLibraryDTO = Converter.FromLibraryToOutLibraryDTO(coreUpdateLibrary);

        return Ok(responseOutLibraryDTO);
    }

    [HttpDelete]
    [Route("api/v1/deleteLibrary/{id}")]
    public async Task<ActionResult<Library>> DeleteLibrary(int id) {

        if(id < 0) {
            return BadRequest("Invalid id");
        }

        await _service.DeleteLibrary(id);
        return Ok();
    }

    [HttpGet]
    [Route("api/v1/{searchedWord}/{id}")]
    public async Task<ActionResult<Book>> SearchBookByKeyword (int id, string searchedWord) {
        if(id < 0) {
            return BadRequest("Invalid id");
        }

        if(searchedWord == null) {
            return BadRequest("Invalid keyword");
        }

        var book = await _service.SearchBookByKeyword(id, searchedWord);

        if(book == null) {
            return NotFound("There is no book with this keyword");
        }

        var bookDTO = Converter.FromBookToOutBookDTO(book);

        return Ok(bookDTO);
    }
}