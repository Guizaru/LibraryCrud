using CrudProject.Data;
using CrudProject.DTO.Author;
using CrudProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Services.Author;

public class AuthorService : IAuthorInterface
{

    private readonly AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseModel<List<AuthorModel>>> ListAuthor()
    {
        ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
        try
        {
            var authors = await _context.Authors.ToListAsync();

            response.Data = authors;
            response.Message = "100% of Authors collected.";
            return response;

        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<AuthorModel>> FindAuthorById(int authorId)
    {
        ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
        
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync
                (authorData => authorData.Id.Equals(authorId));
            if (author == null)
            {
                response.Message = "Author does not exist on database.";
                return response;
            }
            else
            {
                response.Data = author;
                response.Message = "Author has been found.";
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

    public async Task<ResponseModel<AuthorModel>> FindAuthorByBookId(int bookId)
    {
        ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
        
        try
        {
            var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync
                (bookData => bookData.Id.Equals(bookId));
            if (book == null)
            {
                response.Message = "Book does not exist on database.";
                return response;
            }
            else
            {
                response.Data = book.Author;
                response.Message = "Author has been found.";
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

    public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(DtoCreateAuthor dtoCreateAuthor)
    {
        ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

        try
        {
            var author = new AuthorModel()
            {
                Name = dtoCreateAuthor.Name,
                Surname = dtoCreateAuthor.Surname
            };

            _context.Add(author);
            await _context.SaveChangesAsync();

            response.Data = await _context.Authors.ToListAsync();
            response.Message = "Author has been created successfully.";
            return response;
            
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(DtoEditAuthor dtoEditAuthor)
    {
        ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
        
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync
                (authorData => authorData.Id.Equals(dtoEditAuthor.Id));
            if (author == null)
            {
                response.Message = "Author does not exist on database.";
                return response;
            }
            else
            {
                author.Name = dtoEditAuthor.Name;
                author.Surname = dtoEditAuthor.Surname;
                
                _context.Update(author);
                await _context.SaveChangesAsync();
                
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author has been updated successfully.";
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

    public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
    {
        ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
        
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync
                (authorData => authorData.Id.Equals(authorId));
            if (author == null)
            {
                response.Message = "Author does not exist on database.";
                return response;
            }
            else
            {
                _context.Remove(author);
                await _context.SaveChangesAsync();
                
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author has been deleted successfully.";
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