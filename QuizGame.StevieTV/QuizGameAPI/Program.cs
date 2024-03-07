using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// below option stops the loops from happening when getting, but I think its wrong
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<QuizContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuizGame") ?? throw new InvalidOperationException("Connection string not found")));



// Add services to the container.
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

app.UseCors(options => 
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();