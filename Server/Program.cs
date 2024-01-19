using Microsoft.EntityFrameworkCore;
using Server;
using Server.Mutations;
using Server.Queries;
using Server.Subscriptions;
using Server.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSingleton<ITopicEventSender, ITopicEventSender>();
builder.Services.AddDbContext<BookDbContext>(options => options.UseInMemoryDatabase(databaseName: "Books" ));

builder.Services.AddGraphQLServer()
    .AddType<BookType>()
    .AddQueryType<Query>()
    .AddMutationType<BookMutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseWebSockets();
app.UseEndpoints(configure: end =>
{
    end.MapGraphQL();
});

app.UseHttpsRedirection();

app.Run();

