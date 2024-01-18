using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}