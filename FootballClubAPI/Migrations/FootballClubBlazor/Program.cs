using Microsoft.EntityFrameworkCore;
using FootballClubAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FutbolClubContext>(options =>
    options.UseSqlServer("Server=LAPTOP-HEDUSGRR\\SQLEXPRESS;Database=FutbolClubDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
