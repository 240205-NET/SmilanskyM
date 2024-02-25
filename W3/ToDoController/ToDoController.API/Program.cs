using Microsoft.EntityFrameworkCore;
using ToDoController.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDoDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the ToDoContext for Dependency Injection
// Singleton, Scoped, Transient
//builder.Services.AddScoped<TodoContext>(opt => new TodoContext(builder.Configuration.GetConnectionString("Default")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
