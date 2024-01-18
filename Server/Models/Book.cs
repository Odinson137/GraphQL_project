namespace Server.Models;

public class Book
{
    public int BookId { get; set; }
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
    public required string Title { get; set; }
    public required string Text { get; set; }
}