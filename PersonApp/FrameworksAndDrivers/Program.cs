using Application.Services;
using InterfaceAdapters.Data.DataContext;
using InterfaceAdapters.Data.Persistence.Seeds;
using InterfaceAdapters.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<AddPersonService>();
builder.Services.AddScoped<UpdatePersonService>();
builder.Services.AddScoped<DeletePersonService>();
builder.Services.AddScoped<FilterPersonService>();
builder.Services.AddScoped<GetAllPersonService>();
builder.Services.AddScoped<GetPersonByIdService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PersonAppDbContext>();

    await PersonAppSeeder.SeedAsync(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
