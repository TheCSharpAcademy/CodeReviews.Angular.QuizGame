using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Data;

var builder = WebApplication.CreateBuilder(args);
var MyAllowOrigins = "_myAllowOrigins";

// Add services to the container.
builder.Services.AddDbContext<QuizContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowOrigins,
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors(MyAllowOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
