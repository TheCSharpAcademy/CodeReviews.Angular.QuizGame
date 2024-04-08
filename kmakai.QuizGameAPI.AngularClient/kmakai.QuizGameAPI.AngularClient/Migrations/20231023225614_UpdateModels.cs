using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kmakai.QuizGameAPI.AngularClient.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Quizzes_QuizId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_QuizId",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_QuizId",
                table: "Games",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Quizzes_QuizId",
                table: "Games",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
