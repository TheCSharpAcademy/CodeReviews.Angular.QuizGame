using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Models;

namespace QuizGameAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { Id = 1, QuizName = "History" },
                new Quiz { Id = 2, QuizName = ".NET core" },
                new Quiz { Id = 3, QuizName = "Pokemon" }
            );
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, QuizId = 1, PlayerName = "Peter", TotalAmountOfQuestions = 10, CorrectAmountOfAnswers = 8 },
                new Game { Id = 2, QuizId = 2, PlayerName = "Michiel", TotalAmountOfQuestions = 10, CorrectAmountOfAnswers = 6 },
                new Game { Id = 3, QuizId = 3, PlayerName = "Ash", TotalAmountOfQuestions = 10, CorrectAmountOfAnswers = 10 }
            );
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuizQuestion = "What was the name of the first President of the United States?",
                    Answer1 = "George Washington",
                    Answer2 = "Thomas Jefferson",
                    Answer3 = "John Adams",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 2,
                    QuizQuestion = "Who wrote Hamlet?",
                    Answer1 = "William Shakespeare",
                    Answer2 = "Mark Twain",
                    Answer3 = "Charles Dickens",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 3,
                    QuizQuestion = "What year did World War II begin?",
                    Answer1 = "1914",
                    Answer2 = "1939",
                    Answer3 = "1941",
                    CorrectAnswer = 2,
                    QuizId = 1
                },
                new Question
                {
                    Id = 4,
                    QuizQuestion = "What is the Declaration of Independence?",
                    Answer1 = "A novel by Charles Dickens",
                    Answer2 = "A formal statement adopted by the Continental Congress",
                    Answer3 = "The first book of the Bible",
                    CorrectAnswer = 2,
                    QuizId = 1
                },
                new Question
                {
                    Id = 5,
                    QuizQuestion = "Who discovered America?",
                    Answer1 = "Christopher Columbus",
                    Answer2 = "Leif Erikson",
                    Answer3 = "Marco Polo",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 6,
                    QuizQuestion = "What was the outcome of the Battle of Hastings?",
                    Answer1 = "Victory for the Vikings",
                    Answer2 = "A draw",
                    Answer3 = "Victory for the Normans",
                    CorrectAnswer = 3,
                    QuizId = 1
                },
                new Question
                {
                    Id = 7,
                    QuizQuestion = "What was the Treaty of Versailles?",
                    Answer1 = "An agreement ending World War I",
                    Answer2 = "A peace treaty between France and England",
                    Answer3 = "A trade agreement between Germany and Russia",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 8,
                    QuizQuestion = "Who was the first woman to fly across the Atlantic Ocean?",
                    Answer1 = "Amelia Earhart",
                    Answer2 = "Sally Ride",
                    Answer3 = "Valentina Tereshkova",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 9,
                    QuizQuestion = "What was the Boston Tea Party?",
                    Answer1 = "A tea shop in Boston",
                    Answer2 = "A political protest against British taxation",
                    Answer3 = "A famous Boston restaurant",
                    CorrectAnswer = 2,
                    QuizId = 1
                },
                new Question
                {
                    Id = 10,
                    QuizQuestion = "What was the outcome of the French Revolution?",
                    Answer1 = "The establishment of the French Republic",
                    Answer2 = "The rise of Napoleon Bonaparte",
                    Answer3 = "The unification of Italy",
                    CorrectAnswer = 1,
                    QuizId = 1
                },
                new Question
                {
                    Id = 11,
                    QuizQuestion = "What is the latest LTS release of.NET Core?",
                    Answer1 = ".NET Core 5.0",
                    Answer2 = ".NET Core 6.0",
                    Answer3 = ".NET Core 8.0",
                    CorrectAnswer = 3,
                    QuizId = 2
                },
                new Question
                {
                    Id = 12,
                    QuizQuestion = "What is the primary purpose of dependency injection in.NET Core?",
                    Answer1 = "To simplify object creation",
                    Answer2 = "To enforce strict typing rules",
                    Answer3 = "To prevent memory leaks",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 13,
                    QuizQuestion = "What is ASP.NET Core?",
                    Answer1 = "A game development engine",
                    Answer2 = "A cross-platform framework for building modern, cloud-based, internet-connected applications",
                    Answer3 = "A database management system",
                    CorrectAnswer = 2,
                    QuizId = 2
                },
                new Question
                {
                    Id = 14,
                    QuizQuestion = "What is Entity Framework Core?",
                    Answer1 = "A game engine",
                    Answer2 = "An open-source Object-Relational Mapping (ORM) framework for.NET",
                    Answer3 = "A graphics rendering library",
                    CorrectAnswer = 2,
                    QuizId = 2
                },
                new Question
                {
                    Id = 15,
                    QuizQuestion = "What is LINQ in.NET?",
                    Answer1 = "Language Integrated Query",
                    Answer2 = "Library for Input/Output operations",
                    Answer3 = "Local Interconnect Network",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 16,
                    QuizQuestion = "What is the difference between IWebHostEnvironment and IHostingEnvironment in ASP.NET Core?",
                    Answer1 = "IWebHostEnvironment is used in ASP.NET Core 3.0 and later, while IHostingEnvironment is used in earlier versions",
                    Answer2 = "IWebHostEnvironment is used for hosting environments, while IHostingEnvironment is used for development environments",
                    Answer3 = "Both are used interchangeably",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 17,
                    QuizQuestion = "What is Razor Pages in ASP.NET Core?",
                    Answer1 = "A page-based programming model that simplifies coding page-focused scenarios",
                    Answer2 = "A template engine for creating HTML pages",
                    Answer3 = "A tool for debugging ASP.NET Core applications",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 18,
                    QuizQuestion = "What is SignalR in ASP.NET Core?",
                    Answer1 = "A library for adding real-time web functionality to apps",
                    Answer2 = "A tool for managing application state",
                    Answer3 = "A framework for building microservices",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 19,
                    QuizQuestion = "What is Blazor in ASP.NET Core?",
                    Answer1 = "A framework for building interactive client-side web UI with.NET",
                    Answer2 = "A server-side rendering technology",
                    Answer3 = "A tool for automating build processes",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 20,
                    QuizQuestion = "What is the purpose of the Startup class in ASP.NET Core?",
                    Answer1 = "To configure services and the app's request pipeline",
                    Answer2 = "To handle application startup events",
                    Answer3 = "To manage application state",
                    CorrectAnswer = 1,
                    QuizId = 2
                },
                new Question
                {
                    Id = 21,
                    QuizQuestion = "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?",
                    Answer1 = "Ditto",
                    Answer2 = "Eevee",
                    Answer3 = "Pikachu",
                    CorrectAnswer = 1,
                    QuizId = 3
                },
                new Question
                {
                    Id = 22,
                    QuizQuestion = "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?",
                    Answer1 = "Charizard",
                    Answer2 = "Jigglypuff",
                    Answer3 = "Umbreon",
                    CorrectAnswer = 3,
                    QuizId = 3
                },
                new Question
                {
                    Id = 23,
                    QuizQuestion = "What's the tallest Pokemon from Generation 1?",
                    Answer1 = "Onix",
                    Answer2 = "Snorlax",
                    Answer3 = "Pidgeot",
                    CorrectAnswer = 1,
                    QuizId = 3
                },
                new Question
                {
                    Id = 24,
                    QuizQuestion = "True or false: All types are in Generation 1.",
                    Answer1 = "True",
                    Answer2 = "False",
                    Answer3 = "It depends",
                    CorrectAnswer = 2,
                    QuizId = 3
                },
                new Question
                {
                    Id = 25,
                    QuizQuestion = "Check all the poison types.",
                    Answer1 = "Gengar",
                    Answer2 = "Nidoran (both)",
                    Answer3 = "Caterpie",
                    CorrectAnswer = 1,
                    QuizId = 3
                },
                new Question
                {
                    Id = 26,
                    QuizQuestion = "What's the most rare Electric type in Generation 1?",
                    Answer1 = "Zapdos",
                    Answer2 = "Raichu",
                    Answer3 = "Electabuzz",
                    CorrectAnswer = 1,
                    QuizId = 3
                },
                new Question
                {
                    Id = 27,
                    QuizQuestion = "How many Pokemon have more than one set of eyes?",
                    Answer1 = "3",
                    Answer2 = "6",
                    Answer3 = "9",
                    CorrectAnswer = 3,
                    QuizId = 3
                },
                new Question
                {
                    Id = 28,
                    QuizQuestion = "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?",
                    Answer1 = "Ditto",
                    Answer2 = "Eevee",
                    Answer3 = "Pikachu",
                    CorrectAnswer = 1,
                    QuizId = 3
                },
                new Question
                {
                    Id = 29,
                    QuizQuestion = "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?",
                    Answer1 = "Charizard",
                    Answer2 = "Jigglypuff",
                    Answer3 = "Umbreon",
                    CorrectAnswer = 3,
                    QuizId = 3
                },
                new Question
                {
                    Id = 30,
                    QuizQuestion = "What's the tallest Pokemon from Generation 1?",
                    Answer1 = "Onix",
                    Answer2 = "Snorlax",
                    Answer3 = "Pidgeot",
                    CorrectAnswer = 1,
                    QuizId = 3
                }
            );
        }
    }
}
