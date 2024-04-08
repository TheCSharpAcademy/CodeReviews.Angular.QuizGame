using Microsoft.EntityFrameworkCore;
using kmakai.QuizGameAPI.AngularClient.Models;

namespace kmakai.QuizGameAPI.AngularClient.Data;

public class QuizContext : DbContext
{

    public DbSet<Quiz> Quizzes { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;

    public QuizContext(DbContextOptions<QuizContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>()
           .HasMany(q => q.Questions)
           .WithOne(q => q.Quiz)
           .HasForeignKey(q => q.QuizId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Games)
            .WithOne(q => q.Quiz)
            .HasForeignKey(q => q.QuizId)
            .OnDelete(DeleteBehavior.Cascade);

       


    }

}
