using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameVariable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAmountOfAnswers",
                table: "GameRecords",
                newName: "CorrectAmountOfQuestions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAmountOfQuestions",
                table: "GameRecords",
                newName: "CorrectAmountOfAnswers");
        }
    }
}
