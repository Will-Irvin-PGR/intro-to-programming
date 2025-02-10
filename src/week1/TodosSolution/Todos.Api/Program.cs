

using Marten;
using Todos.Api.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("todos") ??
    throw new Exception("Can't start the api without a connection string");
builder.Services.AddMarten(builder =>
{
    builder.Connection(connectionString);
});

// Above line is config for inside app
var app = builder.Build();
// Below is config for HTTP requests/responses

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapTodos();

app.Run();