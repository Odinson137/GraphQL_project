using Server.Models;

namespace Server.Types;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Field(b => b.BookId).Type<IdType>();
        descriptor.Field(b => b.Title).Type<StringType>();
        descriptor.Field(b => b.Text).Type<StringType>();
        descriptor.Field(b => b.UserId).Type<IntType>();
    }
}