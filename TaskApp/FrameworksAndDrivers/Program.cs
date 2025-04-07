using Application.UseCases;
using Domain.Interfaces;
using InterfaceAdapters.DataContext;
using InterfaceAdapters.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

builder.Services.AddScoped<AddToDoItem>();
builder.Services.AddScoped<UpdateToDoItem>();
builder.Services.AddScoped<DeleteToDoItem>();
builder.Services.AddScoped<GetAllToDoItems>();
builder.Services.AddScoped<GetToDoItemById>();
builder.Services.AddScoped<BulkAddToDoItems>();
builder.Services.AddScoped<BulkDeleteToDoItems>();

builder.Services.AddControllers();

builder.Services.AddDbContext<TaskAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ToDo API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
