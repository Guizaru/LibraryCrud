using CrudProject.DTO.Author;
using CrudProject.Models;

namespace CrudProject.Services.Author;

public interface IAuthorInterface
{
    Task<ResponseModel<List<AuthorModel>>> ListAuthor();
    Task<ResponseModel<AuthorModel>> FindAuthorById(int authorId);
    Task<ResponseModel<AuthorModel>> FindAuthorByBookId(int bookId);

    Task<ResponseModel<List<AuthorModel>>> CreateAuthor(DtoCreateAuthor dtoCreateAuthor);
    Task<ResponseModel<List<AuthorModel>>> EditAuthor(DtoEditAuthor dtoEditAuthor);
    Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
        
}