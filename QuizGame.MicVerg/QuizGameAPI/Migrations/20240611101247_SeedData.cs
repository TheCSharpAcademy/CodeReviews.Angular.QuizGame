using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuizRecords",
                columns: new[] { "Id", "QuizName" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, ".NET core" },
                    { 3, "Pokemon" }
                });

            migrationBuilder.InsertData(
                table: "GameRecords",
                columns: new[] { "Id", "CorrectAmountOfAnswers", "PlayerName", "QuizId", "TotalAmountOfQuestions" },
                values: new object[,]
                {
                    { 1, 8, "Peter", 1, 10 },
                    { 2, 6, "Michiel", 2, 10 },
                    { 3, 10, "Ash", 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "QuestionRecords",
                columns: new[] { "Id", "Answer1", "Answer2", "Answer3", "CorrectAnswer", "QuizId", "QuizQuestion" },
                values: new object[,]
                {
                    { 1, "George Washington", "Thomas Jefferson", "John Adams", 1, 1, "What was the name of the first President of the United States?" },
                    { 2, "William Shakespeare", "Mark Twain", "Charles Dickens", 1, 1, "Who wrote Hamlet?" },
                    { 3, "1914", "1939", "1941", 2, 1, "What year did World War II begin?" },
                    { 4, "A novel by Charles Dickens", "A formal statement adopted by the Continental Congress", "The first book of the Bible", 2, 1, "What is the Declaration of Independence?" },
                    { 5, "Christopher Columbus", "Leif Erikson", "Marco Polo", 1, 1, "Who discovered America?" },
                    { 6, "Victory for the Vikings", "A draw", "Victory for the Normans", 3, 1, "What was the outcome of the Battle of Hastings?" },
                    { 7, "An agreement ending World War I", "A peace treaty between France and England", "A trade agreement between Germany and Russia", 1, 1, "What was the Treaty of Versailles?" },
                    { 8, "Amelia Earhart", "Sally Ride", "Valentina Tereshkova", 1, 1, "Who was the first woman to fly across the Atlantic Ocean?" },
                    { 9, "A tea shop in Boston", "A political protest against British taxation", "A famous Boston restaurant", 2, 1, "What was the Boston Tea Party?" },
                    { 10, "The establishment of the French Republic", "The rise of Napoleon Bonaparte", "The unification of Italy", 1, 1, "What was the outcome of the French Revolution?" },
                    { 11, ".NET Core 5.0", ".NET Core 6.0", ".NET Core 8.0", 3, 2, "What is the latest LTS release of.NET Core?" },
                    { 12, "To simplify object creation", "To enforce strict typing rules", "To prevent memory leaks", 1, 2, "What is the primary purpose of dependency injection in.NET Core?" },
                    { 13, "A game development engine", "A cross-platform framework for building modern, cloud-based, internet-connected applications", "A database management system", 2, 2, "What is ASP.NET Core?" },
                    { 14, "A game engine", "An open-source Object-Relational Mapping (ORM) framework for.NET", "A graphics rendering library", 2, 2, "What is Entity Framework Core?" },
                    { 15, "Language Integrated Query", "Library for Input/Output operations", "Local Interconnect Network", 1, 2, "What is LINQ in.NET?" },
                    { 16, "IWebHostEnvironment is used in ASP.NET Core 3.0 and later, while IHostingEnvironment is used in earlier versions", "IWebHostEnvironment is used for hosting environments, while IHostingEnvironment is used for development environments", "Both are used interchangeably", 1, 2, "What is the difference between IWebHostEnvironment and IHostingEnvironment in ASP.NET Core?" },
                    { 17, "A page-based programming model that simplifies coding page-focused scenarios", "A template engine for creating HTML pages", "A tool for debugging ASP.NET Core applications", 1, 2, "What is Razor Pages in ASP.NET Core?" },
                    { 18, "A library for adding real-time web functionality to apps", "A tool for managing application state", "A framework for building microservices", 1, 2, "What is SignalR in ASP.NET Core?" },
                    { 19, "A framework for building interactive client-side web UI with.NET", "A server-side rendering technology", "A tool for automating build processes", 1, 2, "What is Blazor in ASP.NET Core?" },
                    { 20, "To configure services and the app's request pipeline", "To handle application startup events", "To manage application state", 1, 2, "What is the purpose of the Startup class in ASP.NET Core?" },
                    { 21, "Ditto", "Eevee", "Pikachu", 1, 3, "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?" },
                    { 22, "Charizard", "Jigglypuff", "Umbreon", 3, 3, "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?" },
                    { 23, "Onix", "Snorlax", "Pidgeot", 1, 3, "What's the tallest Pokemon from Generation 1?" },
                    { 24, "True", "False", "It depends", 2, 3, "True or false: All types are in Generation 1." },
                    { 25, "Gengar", "Nidoran (both)", "Caterpie", 1, 3, "Check all the poison types." },
                    { 26, "Zapdos", "Raichu", "Electabuzz", 1, 3, "What's the most rare Electric type in Generation 1?" },
                    { 27, "3", "6", "9", 3, 3, "How many Pokemon have more than one set of eyes?" },
                    { 28, "Ditto", "Eevee", "Pikachu", 1, 3, "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?" },
                    { 29, "Charizard", "Jigglypuff", "Umbreon", 3, 3, "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?" },
                    { 30, "Onix", "Snorlax", "Pidgeot", 1, 3, "What's the tallest Pokemon from Generation 1?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuestionRecords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuizRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuizRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuizRecords",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
