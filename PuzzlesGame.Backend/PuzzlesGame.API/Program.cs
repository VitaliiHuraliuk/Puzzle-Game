using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Puzzle.DAL;
using Puzzle.Domain;
using Microsoft.AspNetCore.Cors;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDalDependencies();
builder.Services.RegisterDomainDependencies();

builder.Services.AddDbContext<PuzzleDbContext>(options =>
            options.UseSqlServer("Server=.;Database=PuzzleDbcontext;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"));

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
