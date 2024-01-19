using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Queries;

public class Query
{
    private readonly ILogger<Query> _logger;
    public Query(ILogger<Query> logger)
    {
        _logger = logger;
    }
    
    [GraphQLName("books")]
    [GraphQLDescription("Get books")]
    [UseProjection]
    public async Task<ICollection<Book>> GetBooks([Service] BookDbContext context)
    {
        return await context.Books.ToListAsync();
    }
    
    [GraphQLName("paginationBooks")]
    [GraphQLDescription("Get books")]
    [UsePaging]
    public IQueryable<Book> GetPaginationBooks([Service] BookDbContext context)
    {
        return context.Books;
    }
    
    
    [GraphQLName("sortedBooks")]
    [GraphQLDescription("Get books")]
    [UseProjection]
    public IQueryable<Book> GetSortedBooks([Service] BookDbContext context)
    {
        var books = context.Books;
        _logger.LogInformation(JsonSerializer.Serialize(books));
        return books;
    }
    
    [GraphQLName("filterBooks")]
    [GraphQLDescription("Get books")]
    [UseFiltering]
    public IQueryable<Book> GetFilterBooks([Service] BookDbContext context)
    {
        var books = context.Books;
        return books;
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