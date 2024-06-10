using Microsoft.AspNetCore.Mvc;
using webapi.Helper;

namespace webapi.Controllers;

[ApiController]

public class BookController : ControllerBase {
    private readonly IBookService _service;

    public BookController(IBookService bookService)
    {
        _service = bookService;
    }

    [HttpGet]
    [Route("api/v1/books")]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll() {
        List<Book> DBBookList = await _service.GetAll();
        
        if(DBBookList.Count == 0) {
            return NotFound("There are no books in the database");
        }

        var bookDTOList = new List<OutBookDTO>();

        foreach (Book book in DBBookList) {
            bookDTOList.Add(Converter.FromBookToOutBookDTO(book));
        }

        return Ok(bookDTOList);
    }

    [HttpGet]
    [Route("api/v1/books/{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id) {
        
        if(id < 0) {
            return BadRequest("Invalid id");
        }
        
        var book = await _service.GetBookById(id);
        
        if(book == null) {
            return NotFound("There is no book with this id");
        }

        var bookDTO = Converter.FromBookToOutBookDTO(book);

        return Ok(bookDTO);
    }

    [HttpPost]
    [Route("api/v1/addBooks")]
    public async Task<ActionResult<Book>> AddBook(InBookDTO newInDTOBook) {
        if(newInDTOBook == null) {
            return BadRequest("Invalid book data");
        }

        if(newInDTOBook.Pages < 0) {
            return BadRequest("The pages attribute can not be negative");
        }

        var newBook = Converter.FromInBookDTOToBook(newInDTOBook);

        await _service.AddBook(newBook);

        var responeOutBookDTO = Converter.FromBookToOutBookDTO(newBook);

        return Created("", responeOutBookDTO);  
    }

    [HttpPut]
    [Route("api/v1/updateBook/{id}")]
    public async Task<ActionResult<Book>> UpdateBook(int id, InBookDTO updateInBookDTOFromBody) {

        if(updateInBookDTOFromBody == null) {
            return BadRequest("Invalid book data");
        }

        if(updateInBookDTOFromBody.Pages < 0) {
            return BadRequest("The pages attribute can not be negative");
        }

        if(id < 0) {
            return BadRequest("Invalid id");
        }

        var coreUpdateBook = Converter.FromInBookDTOToBook(updateInBookDTOFromBody);

        await _service.UpdateBook(id, coreUpdateBook);

        var responeOutBookDTO = Converter.FromBookToOutBookDTO(coreUpdateBook);
        
        return Ok(responeOutBookDTO);
    }

    [HttpDelete]
    [Route("api/v1/deleteBook/{id}")]
    public async Task<ActionResult<Book>> DeleteBook(int id) {
        
        if(id < 0) {
            return BadRequest("Invalid id");
        }
        
        await _service.DeleteBook(id);
        return Ok(); 
    }

    [HttpPut]
    [Route("api/v1/insertSecondVersionOfBooks")]
    public async Task<ActionResult<List<Book>>> InsertSecondVersionOfBooks([FromBody] List<int> ids) {
        if(ids == null) {
            return BadRequest("Invalid ids");
        }

        await _service.InsertSecondVersionOfBooks(ids);
        return Ok();
    }

}