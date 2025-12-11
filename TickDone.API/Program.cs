var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/todos", async (AppDbContext db) =>
{
    var todos = await db.ToDos.ToListAsync();
    return Results.Ok(todos);
})
.WithName("GetTodos");

app.MapPost("/todos", async (CreateToDoRequest request, AppDbContext db) =>
{
    var todo = new ToDo
    {
        Id = 1,
        TaskName = request.TaskName,
        Deadline = request.Deadline,
        Done = false
    };

    db.ToDos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todos/{todo.Id}", todo);
})
.WithName("CreateTodo");

app.Run();
