using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Models;

namespace QuizGameAPI.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options)
             : base(options) { }

        public DbSet<Quiz> QuizRecords { get; set; }
        public DbSet<Game> GameRecords { get; set; }
        public DbSet<Question> QuestionRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Quiz)
                .WithMany(q => q.Games)
                .HasForeignKey(g => g.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne(g => g.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(g => g.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
