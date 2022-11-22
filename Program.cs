using Backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(option =>
            option.AddPolicy(name: "MyAllowSpecificOrigins",
             builder =>
             {
                 builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin();
             }));


// Conexão com banco meu banco local.
builder.Services.AddDbContext<LibDB>(options => options.UseSqlServer
("Server=LUCASPOLATTO-PC\\SQLEXPRESS;DataBase=LibManagerDB;Trusted_Connection=True;Encrypt=False"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");

app.MapControllers();

app.Run();