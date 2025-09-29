using System.Text.Json.Serialization;

namespace CrudProject.Models;

public class BookModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    [JsonIgnore]
    public AuthorModel Author { get; set; }

}
