using Server.Models;

namespace Server.Mutations;

public class BookMutation
{
    [GraphQLName("book")]
    [GraphQLDescription("Insert books")]
    public async Task<Book> Book([Service] BookDbContext context, [Service] ILogger<BookMutation> logger, 
        string title, int authorId, string text)
    {
        logger.LogInformation("Insert book");
        var book = new Book
        {
            UserId = authorId,
            Title = title,
            Text = text,
        };

        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
        return book;
    }
}