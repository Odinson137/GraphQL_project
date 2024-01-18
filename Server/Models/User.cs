namespace Server.Models;

public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public ICollection<Book>? Books { get; set; }
}