using Microsoft.EntityFrameworkCore;
using Server;
using Server.Models;
using Server.Mutations;
using Server.Queries;
using Server.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BookDbContext>(options => options.UseInMemoryDatabase(databaseName: "Books" ));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookType>()
    .AddMutationType<BookMutation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseEndpoints(configure: end =>
{
    end.MapGraphQL();
});

app.UseHttpsRedirection();

app.Run();

