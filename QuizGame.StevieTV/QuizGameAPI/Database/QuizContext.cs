using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Models;

namespace QuizGameAPI.Database;

public class QuizContext(DbContextOptions<QuizContext> options) : DbContext(options)
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Questions)
            .WithOne(q => q.CurrentQuiz)
            .HasForeignKey(q => q.QuizId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Games)
            .WithOne(q => q.CurrentQuiz)
            .HasForeignKey(q => q.QuizId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}