using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class QuizContext : DbContext
{
    public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<Quiz> Quizes { get; set; }
    public DbSet<TQuestion> Questions { get; set; }


}
