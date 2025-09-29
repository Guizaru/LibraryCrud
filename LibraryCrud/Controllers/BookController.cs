using CrudProject.DTO.Book;
using CrudProject.Models;
using CrudProject.Services.Book;
using Microsoft.AspNetCore.Mvc;

namespace CrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        
        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }
        
        [HttpGet("ListBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBook()
        {
            var books = await _bookInterface.ListBook();
            return Ok(books);
        }
        
        [HttpGet("FindBookById/{bookId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> FindBookById(int bookId)
        {
            var authors = await _bookInterface.FindBookById(bookId);
            return Ok(authors);
        }
        
        [HttpGet("FindBookByAuthorId/{authorId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> FindBookByAuthorId(int authorId)
        {
            var books = await _bookInterface.FindBookByAuthorId(authorId);
            return Ok(books);
        }
        
        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<BookModel>>> CreateAuthor(DtoCreateBook createBook)
        {
            var books = await _bookInterface.CreateBook(createBook);
            return Ok(books);
        }
        
        [HttpPut("EditBook")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> EditAuthor(DtoEditBook editBook)
        {
            var books = await _bookInterface.EditBook(editBook);
            return Ok(books);
        }
        
        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> DeleteAuthor(int bookId)
        {
            var authors = await _bookInterface.DeleteBook(bookId);
            return Ok(authors);
        }
    }
}