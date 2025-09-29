using CrudProject.Data;
using CrudProject.DTO.Book;
using CrudProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Services.Book;

public class BookService : IBookInterface
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<List<BookModel>>> ListBook()
    {
        ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
        try
        {
            var books = await _context.Books.ToListAsync();

            response.Data = books;
            response.Message = "100% of Books collected.";
            return response;

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<BookModel>> FindBookById(int bookId)
    {
        ResponseModel<BookModel> response = new ResponseModel<BookModel>();
        
        try
        {
            var book = await _context.Books.FirstOrDefaultAsync
                (bookData => bookData.Id.Equals(bookId));
            if (book == null)
            {
                response.Message = "Book does not exist on database.";
                return response;
            }
            else
            {
                response.Data = book;
                response.Message = "Book has been found.";
                return response;
            }

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> FindBookByAuthorId(int authorId)
    {
        ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
        
        try
        {
            var book = await _context.Books.Include(a => a.Author)
                .Where(bookData => bookData.Author.Id.Equals(authorId)).ToListAsync();
            if (!book.Any())
            {
                response.Message = "Author does not exist on database.";
                return response;
            }
            else
            {
                response.Data = book;
                var numberOfBooks = await _context.Books.Where(b => b.Author.Id == authorId)
                    .CountAsync();
                response.Message = $"Numbers of books under the author's id: {numberOfBooks}";
                return response;
            }

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> CreateBook(DtoCreateBook dtoCreatebook)
    {
        ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

        try
        {
            var author = await _context.Authors.
                    FirstOrDefaultAsync(a => a.Id == dtoCreatebook.AuthorId);

            if (author == null)
            {
                response.Message = "Author does not exist on database.";
                return response;
            }
            
            var book = new BookModel()
            {
                Title = dtoCreatebook.Title,
                Author = author
            };
            _context.Add(book);
            await _context.SaveChangesAsync();

            response.Data = await _context.Books.Include(a => a.Author).ToListAsync();
            response.Message = "Book has been created successfully.";
            return response;
            
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<BookModel>>> EditBook(DtoEditBook dtoEditBook)
    {
        ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
        
        try
        {
            var book = await _context.Books.FirstOrDefaultAsync
                (bookData => bookData.Id.Equals(dtoEditBook.Id));
            if (book == null)
            {
                response.Message = "Book does not exist on database.";
                return response;
            }
            else
            {
                book.Title = dtoEditBook.Title;
                _context.Update(book);
                await _context.SaveChangesAsync();
                
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book has been updated successfully.";
                return response;
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }
    
    public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
    {
        ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
        
        try
        {
            var book = await _context.Books.FirstOrDefaultAsync
                (bookData => bookData.Id.Equals(bookId));
            if (book == null)
            {
                response.Message = "Book does not exist on database.";
                return response;
            }
            else
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
                
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book has been deleted successfully.";
                return response;
            }

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }
}