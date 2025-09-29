﻿namespace CrudProject.Models;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<BookModel> Books { get; set; }
}