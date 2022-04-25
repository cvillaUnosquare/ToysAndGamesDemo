using Microsoft.EntityFrameworkCore;
using ToysAndGames.Model.Contexts;
using ToysAndGames.Services.Contracts;
using ToysAndGames.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToysAndGamesDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("t&gamesConnString"),
        x => x.MigrationsAssembly("ToysAndGames.Model")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();

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
