using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Types;

namespace Server.Queries;

public class Query
{
    [GraphQLName("books")]
    [GraphQLDescription("Get books")]
    public async Task<ICollection<Book>> GetBooks([Service] BookDbContext context)
    {
        return await context.Books.ToListAsync();
    }
    
    [GraphQLName("book")]
    [GraphQLDescription("Get book")]
    public async Task<Book?> GetBook([Service] BookDbContext context, [Service] ILogger<Query> logger, int bookId)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
        logger.LogInformation(JsonSerializer.Serialize(book));
        return book;
    }
}