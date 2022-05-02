using Microsoft.EntityFrameworkCore;
using ToysAndGames.Model.Contexts;
using ToysAndGames.Services.Contracts;
using ToysAndGames.Services.Services;

<<<<<<< HEAD
var MyAllowSpecificOrigins = "_ToysPolicy";
=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
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

<<<<<<< HEAD
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
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

<<<<<<< HEAD
app.UseCors(MyAllowSpecificOrigins);

=======
>>>>>>> 0aaa84207e6491bd2412b80bd7b243f04156015b
app.Run();
