using CrudProject.Models;

namespace CrudProject.DTO.Book;

public class DtoCreateBook
{
    public string Title { get; set; }
    public int AuthorId { get; set; }
}