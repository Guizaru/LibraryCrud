using CrudProject.DTO.Author;
using CrudProject.Models;
using CrudProject.Services.Author;
using Microsoft.AspNetCore.Mvc;


namespace CrudProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly IAuthorInterface _authorInterface;
        
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("ListAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthor()
        {
            var authors = await _authorInterface.ListAuthor();
            return Ok(authors);
        }
        
        [HttpGet("FindAuthorById/{authorId}")]
        
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindAuthorById(int authorId)
        {
            var authors = await _authorInterface.FindAuthorById(authorId);
            return Ok(authors);
        }
        
        [HttpGet("FindAuthorByBookId/{bookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> FindAuthorByBookId(int bookId)
        {
            var authors = await _authorInterface.FindAuthorByBookId(bookId);
            return Ok(authors);
        }

        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> CreateAuthor(DtoCreateAuthor createAuthor)
        {
            var authors = await _authorInterface.CreateAuthor(createAuthor);
            return Ok(authors);
        }
        [HttpPut("EditAuthor")]
        
        public async Task<ActionResult<ResponseModel<AuthorModel>>> EditAuthor(DtoEditAuthor editAuthor)
        {
            var authors = await _authorInterface.EditAuthor(editAuthor);
            return Ok(authors);
        }
        
        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> DeleteAuthor(int authorId)
        {
            var authors = await _authorInterface.DeleteAuthor(authorId);
            return Ok(authors);
        }
        
    }
}