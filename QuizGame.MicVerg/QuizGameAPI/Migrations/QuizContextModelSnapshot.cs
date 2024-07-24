﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizGameAPI.Data;

#nullable disable

namespace QuizGameAPI.Migrations
{
    [DbContext(typeof(QuizContext))]
    partial class QuizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizGameAPI.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CorrectAmountOfQuestions")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmountOfQuestions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("GameRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAmountOfQuestions = 8,
                            PlayerName = "Peter",
                            QuizId = 1,
                            TotalAmountOfQuestions = 10
                        },
                        new
                        {
                            Id = 2,
                            CorrectAmountOfQuestions = 6,
                            PlayerName = "Michiel",
                            QuizId = 2,
                            TotalAmountOfQuestions = 10
                        },
                        new
                        {
                            Id = 3,
                            CorrectAmountOfQuestions = 10,
                            PlayerName = "Ash",
                            QuizId = 3,
                            TotalAmountOfQuestions = 10
                        });
                });

            modelBuilder.Entity("QuizGameAPI.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("QuizQuestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("QuestionRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer1 = "George Washington",
                            Answer2 = "Thomas Jefferson",
                            Answer3 = "John Adams",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "What was the name of the first President of the United States?"
                        },
                        new
                        {
                            Id = 2,
                            Answer1 = "William Shakespeare",
                            Answer2 = "Mark Twain",
                            Answer3 = "Charles Dickens",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "Who wrote Hamlet?"
                        },
                        new
                        {
                            Id = 3,
                            Answer1 = "1914",
                            Answer2 = "1939",
                            Answer3 = "1941",
                            CorrectAnswer = 2,
                            QuizId = 1,
                            QuizQuestion = "What year did World War II begin?"
                        },
                        new
                        {
                            Id = 4,
                            Answer1 = "A novel by Charles Dickens",
                            Answer2 = "A formal statement adopted by the Continental Congress",
                            Answer3 = "The first book of the Bible",
                            CorrectAnswer = 2,
                            QuizId = 1,
                            QuizQuestion = "What is the Declaration of Independence?"
                        },
                        new
                        {
                            Id = 5,
                            Answer1 = "Christopher Columbus",
                            Answer2 = "Leif Erikson",
                            Answer3 = "Marco Polo",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "Who discovered America?"
                        },
                        new
                        {
                            Id = 6,
                            Answer1 = "Victory for the Vikings",
                            Answer2 = "A draw",
                            Answer3 = "Victory for the Normans",
                            CorrectAnswer = 3,
                            QuizId = 1,
                            QuizQuestion = "What was the outcome of the Battle of Hastings?"
                        },
                        new
                        {
                            Id = 7,
                            Answer1 = "An agreement ending World War I",
                            Answer2 = "A peace treaty between France and England",
                            Answer3 = "A trade agreement between Germany and Russia",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "What was the Treaty of Versailles?"
                        },
                        new
                        {
                            Id = 8,
                            Answer1 = "Amelia Earhart",
                            Answer2 = "Sally Ride",
                            Answer3 = "Valentina Tereshkova",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "Who was the first woman to fly across the Atlantic Ocean?"
                        },
                        new
                        {
                            Id = 9,
                            Answer1 = "A tea shop in Boston",
                            Answer2 = "A political protest against British taxation",
                            Answer3 = "A famous Boston restaurant",
                            CorrectAnswer = 2,
                            QuizId = 1,
                            QuizQuestion = "What was the Boston Tea Party?"
                        },
                        new
                        {
                            Id = 10,
                            Answer1 = "The establishment of the French Republic",
                            Answer2 = "The rise of Napoleon Bonaparte",
                            Answer3 = "The unification of Italy",
                            CorrectAnswer = 1,
                            QuizId = 1,
                            QuizQuestion = "What was the outcome of the French Revolution?"
                        },
                        new
                        {
                            Id = 11,
                            Answer1 = ".NET Core 5.0",
                            Answer2 = ".NET Core 6.0",
                            Answer3 = ".NET Core 8.0",
                            CorrectAnswer = 3,
                            QuizId = 2,
                            QuizQuestion = "What is the latest LTS release of.NET Core?"
                        },
                        new
                        {
                            Id = 12,
                            Answer1 = "To simplify object creation",
                            Answer2 = "To enforce strict typing rules",
                            Answer3 = "To prevent memory leaks",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is the primary purpose of dependency injection in.NET Core?"
                        },
                        new
                        {
                            Id = 13,
                            Answer1 = "A game development engine",
                            Answer2 = "A cross-platform framework for building modern, cloud-based, internet-connected applications",
                            Answer3 = "A database management system",
                            CorrectAnswer = 2,
                            QuizId = 2,
                            QuizQuestion = "What is ASP.NET Core?"
                        },
                        new
                        {
                            Id = 14,
                            Answer1 = "A game engine",
                            Answer2 = "An open-source Object-Relational Mapping (ORM) framework for.NET",
                            Answer3 = "A graphics rendering library",
                            CorrectAnswer = 2,
                            QuizId = 2,
                            QuizQuestion = "What is Entity Framework Core?"
                        },
                        new
                        {
                            Id = 15,
                            Answer1 = "Language Integrated Query",
                            Answer2 = "Library for Input/Output operations",
                            Answer3 = "Local Interconnect Network",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is LINQ in.NET?"
                        },
                        new
                        {
                            Id = 16,
                            Answer1 = "IWebHostEnvironment is used in ASP.NET Core 3.0 and later, while IHostingEnvironment is used in earlier versions",
                            Answer2 = "IWebHostEnvironment is used for hosting environments, while IHostingEnvironment is used for development environments",
                            Answer3 = "Both are used interchangeably",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is the difference between IWebHostEnvironment and IHostingEnvironment in ASP.NET Core?"
                        },
                        new
                        {
                            Id = 17,
                            Answer1 = "A page-based programming model that simplifies coding page-focused scenarios",
                            Answer2 = "A template engine for creating HTML pages",
                            Answer3 = "A tool for debugging ASP.NET Core applications",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is Razor Pages in ASP.NET Core?"
                        },
                        new
                        {
                            Id = 18,
                            Answer1 = "A library for adding real-time web functionality to apps",
                            Answer2 = "A tool for managing application state",
                            Answer3 = "A framework for building microservices",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is SignalR in ASP.NET Core?"
                        },
                        new
                        {
                            Id = 19,
                            Answer1 = "A framework for building interactive client-side web UI with.NET",
                            Answer2 = "A server-side rendering technology",
                            Answer3 = "A tool for automating build processes",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is Blazor in ASP.NET Core?"
                        },
                        new
                        {
                            Id = 20,
                            Answer1 = "To configure services and the app's request pipeline",
                            Answer2 = "To handle application startup events",
                            Answer3 = "To manage application state",
                            CorrectAnswer = 1,
                            QuizId = 2,
                            QuizQuestion = "What is the purpose of the Startup class in ASP.NET Core?"
                        },
                        new
                        {
                            Id = 21,
                            Answer1 = "Ditto",
                            Answer2 = "Eevee",
                            Answer3 = "Pikachu",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?"
                        },
                        new
                        {
                            Id = 22,
                            Answer1 = "Charizard",
                            Answer2 = "Jigglypuff",
                            Answer3 = "Umbreon",
                            CorrectAnswer = 3,
                            QuizId = 3,
                            QuizQuestion = "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?"
                        },
                        new
                        {
                            Id = 23,
                            Answer1 = "Onix",
                            Answer2 = "Snorlax",
                            Answer3 = "Pidgeot",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "What's the tallest Pokemon from Generation 1?"
                        },
                        new
                        {
                            Id = 24,
                            Answer1 = "True",
                            Answer2 = "False",
                            Answer3 = "It depends",
                            CorrectAnswer = 2,
                            QuizId = 3,
                            QuizQuestion = "True or false: All types are in Generation 1."
                        },
                        new
                        {
                            Id = 25,
                            Answer1 = "Gengar",
                            Answer2 = "Nidoran (both)",
                            Answer3 = "Caterpie",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "Check all the poison types."
                        },
                        new
                        {
                            Id = 26,
                            Answer1 = "Zapdos",
                            Answer2 = "Raichu",
                            Answer3 = "Electabuzz",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "What's the most rare Electric type in Generation 1?"
                        },
                        new
                        {
                            Id = 27,
                            Answer1 = "3",
                            Answer2 = "6",
                            Answer3 = "9",
                            CorrectAnswer = 3,
                            QuizId = 3,
                            QuizQuestion = "How many Pokemon have more than one set of eyes?"
                        },
                        new
                        {
                            Id = 28,
                            Answer1 = "Ditto",
                            Answer2 = "Eevee",
                            Answer3 = "Pikachu",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "Which Pokemon is known for its unique transformation ability to mimic other Pokemon?"
                        },
                        new
                        {
                            Id = 29,
                            Answer1 = "Charizard",
                            Answer2 = "Jigglypuff",
                            Answer3 = "Umbreon",
                            CorrectAnswer = 3,
                            QuizId = 3,
                            QuizQuestion = "Which of the following Pokemon is not part of Generation 1 (the original 151 Pokemon)?"
                        },
                        new
                        {
                            Id = 30,
                            Answer1 = "Onix",
                            Answer2 = "Snorlax",
                            Answer3 = "Pidgeot",
                            CorrectAnswer = 1,
                            QuizId = 3,
                            QuizQuestion = "What's the tallest Pokemon from Generation 1?"
                        });
                });

            modelBuilder.Entity("QuizGameAPI.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuizName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuizRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuizName = "History"
                        },
                        new
                        {
                            Id = 2,
                            QuizName = ".NET core"
                        },
                        new
                        {
                            Id = 3,
                            QuizName = "Pokemon"
                        });
                });

            modelBuilder.Entity("QuizGameAPI.Models.Game", b =>
                {
                    b.HasOne("QuizGameAPI.Models.Quiz", "Quiz")
                        .WithMany("Games")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizGameAPI.Models.Question", b =>
                {
                    b.HasOne("QuizGameAPI.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizGameAPI.Models.Quiz", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
