using Bogus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var persons = Enumerable.Range(1, 100).Select(num => new { Id = num, Name = new Faker().Person.FullName }).ToArray();

app.MapGet("/users-service/users", (string? filter) => persons.Where(p => string.IsNullOrWhiteSpace(filter) || p.Name.Contains(filter)));

app.MapGet("/users-service/users/{id}", (int id) =>
{
    var person = persons.FirstOrDefault(p => p.Id == id);
    return person is not null ? Results.Ok(person) : Results.NotFound();
});

//app.MapGet("/", () => "Hello World Users Api!");

app.UseHttpsRedirection();

app.Run();
