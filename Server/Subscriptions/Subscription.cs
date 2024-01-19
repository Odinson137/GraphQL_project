using System.Text.Json;
using Server.Models;

namespace Server.Subscriptions;

public class Subscription
{
    public Subscription(ILogger<Subscription> logger)
    {
        logger.LogInformation("Sub");
    }
    [Subscribe]
    public Book OnBookUpdateAsync(
        [Service] ILogger<Subscription> logger,
        [EventMessage] Book book)
    {
        logger.LogInformation(JsonSerializer.Serialize(book));
        return book;
    }
}