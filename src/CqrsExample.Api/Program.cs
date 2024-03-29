using CqrsExample.Application;
using CqrsExample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var initialCartId = Guid.NewGuid().ToString();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(initialCartId);

Console.WriteLine("Generating a new cart id: {0}", initialCartId);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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