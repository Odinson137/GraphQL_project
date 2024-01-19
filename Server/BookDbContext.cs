using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Логирование SQL-запросов

        optionsBuilder.LogTo(System.Console.WriteLine);
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }
    
    
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}