using CrudProject.DTO.Book;
using CrudProject.Models;

namespace CrudProject.Services.Book;

public interface IBookInterface
{
    Task<ResponseModel<List<BookModel>>> ListBook();
    Task<ResponseModel<BookModel>> FindBookById(int bookId);
    Task<ResponseModel<List<BookModel>>> FindBookByAuthorId(int authorId);
    
    Task<ResponseModel<List<BookModel>>> CreateBook(DtoCreateBook dtoCreatebook);
    Task<ResponseModel<List<BookModel>>> EditBook(DtoEditBook dtoEditBook);
    Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId);
}