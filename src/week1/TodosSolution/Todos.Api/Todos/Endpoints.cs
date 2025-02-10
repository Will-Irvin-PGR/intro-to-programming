using Marten;

namespace Todos.Api.Todos;

public static class Endpoints
{
    // "Extension Method"
    // Method is added to Endpoint Route Builder, can call the function to initialize them
    public static IEndpointRouteBuilder MapTodos(this IEndpointRouteBuilder builder)
    {
        // GET /todos
        builder.MapGet("/todos", async (IDocumentSession session) =>
        {
            var response = await session.Query<TodoListItem>().ToListAsync();

            return Results.Ok(response);
        });
        // POST /todos
        builder.MapPost("/todos", async (TodoListCreateItem request, IDocumentSession session) =>
        {
            var response = new TodoListItem()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Completed = false,
                CreatedOn = DateTimeOffset.UtcNow
            };

            // Sends response to database service
            session.Store(response);
            // Actually saves changes in the database
            await session.SaveChangesAsync();

            return Results.Ok(response);
        });
        return builder;
    }
}

public record TodoListItem
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Completed { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? CompletedDate { get; set; }
}

public record TodoListCreateItem
{
    public string Description { get; set; } = string.Empty;
}
