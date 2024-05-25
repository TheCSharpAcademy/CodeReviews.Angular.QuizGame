using Microsoft.EntityFrameworkCore;
using QuizGame.Data.Dummies;
using QuizGame.Data.Models;

namespace QuizGame.Data;

public class QuizGameContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Quiz>().HasData(DummyData.GetQuizzes());
        modelBuilder.Entity<Question>().HasData(DummyData.GetQuestions());
        modelBuilder.Entity<Answer>().HasData(DummyData.GetAnswers());
    }
}