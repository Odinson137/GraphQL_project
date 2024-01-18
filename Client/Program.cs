using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

var graphQlHttpClient = new GraphQLHttpClient("http://localhost:5074/graphql", new NewtonsoftJsonSerializer());

var query = new GraphQLRequest()
{
    Query = @"
            query {
                books {
                    bookId
                    title
                    userId
                }
            }",
};

var response = graphQlHttpClient.SendQueryAsync<dynamic>(query).Result;

Console.WriteLine(response.Data);
