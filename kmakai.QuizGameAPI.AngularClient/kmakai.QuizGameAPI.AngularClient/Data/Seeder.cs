using Microsoft.EntityFrameworkCore;
using kmakai.QuizGameAPI.AngularClient.Models;

namespace kmakai.QuizGameAPI.AngularClient.Data;

public class Seeder
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new QuizContext(serviceProvider.GetRequiredService<DbContextOptions<QuizContext>>());

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SeedQuizzes(context);
        SeedQuestions(context);
        
    }

    public static void SeedQuizzes(QuizContext context)
    {

        context.Quizzes.AddRange(
            new Quiz
            {
                Name = "C#",
                Description = "C# Quiz",
            },
            new Quiz
            {
                Name = "JavaScript",
                Description = "JavaScript Quiz",
            },
            new Quiz
            {
                Name = "HTML",
                Description = "HTML Quiz",
            }
            );

        context.SaveChanges();
    }

    public static void SeedQuestions(QuizContext context)
    {
        context.Questions.AddRange(
            new Question
            {
                Text = "What is C#?",
                Answer = "A programming language",
                Option1 = "A programming language",
                Option2 = "A car",
                Option3 = "A Library",
                Option4 = "A framework",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a class?",
                Answer = "A blueprint for an object",
                Option1 = "A blueprint for an object",
                Option2 = "A blueprint for a method",
                Option3 = "A blueprint for a function",
                Option4 = "A blueprint for a variable",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a method?",
                Answer = "A function inside a class",
                Option1 = "A function inside a class",
                Option2 = "A function inside a method",
                Option3 = "A function inside a variable",
                Option4 = "A function inside a namespace",
                QuizId = 1

            },
            new Question
            {
                Text = "What is a namespace?",
                Answer = "A container for classes",
                Option1 = "A container for classes",
                Option2 = "A container for methods",
                Option3 = "A container for functions",
                Option4 = "A container for variables",
                QuizId = 1

            },
            new Question
            {
                Text = "What is a variable?",
                Answer = "A container for data",
                Option1 = "A container for data",
                Option2 = "A container for methods",
                Option3 = "A container for functions",
                Option4 = "A container for classes",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a function?",
                Answer = "A block of code that can be called",
                Option1 = "A block of code that can be called",
                Option2 = "A block of code that can be stored",
                Option3 = "A block of code that can be executed",
                Option4 = "A block of code that can be deleted",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a constructor?",
                Answer = "A method that is called when an object is created",
                Option1 = "A method that is called when an object is created",
                Option2 = "A method that is called when a class is created",
                Option3 = "A method that is called when a variable is created",
                Option4 = "A method that is called when a function is created",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a property?",
                Answer = "A value stored inside an object",
                Option1 = "A value stored inside an object",
                Option2 = "A value stored inside a class",
                Option3 = "A value stored inside a method",
                Option4 = "A value stored inside a variable",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a field?",
                Answer = "A value stored inside a class",
                Option1 = "A value stored inside a class",
                Option2 = "A value stored inside an object",
                Option3 = "A value stored inside a method",
                Option4 = "A value stored inside a variable",
                QuizId = 1
            },
            new Question
            {
                Text = "What is a static member?",
                Answer = "A member that belongs to the class, not an object",
                Option1 = "A member that belongs to the class, not an object",
                Option2 = "A member that belongs to the object, not a class",
                Option3 = "A member that belongs to the method, not a class",
                Option4 = "A member that belongs to the variable, not a class",
                QuizId = 1
            },
            // JavaScript
            new Question
            {
                Text = "What is JavaScript?",
                Answer = "A programming language",
                Option1 = "A programming language",
                Option2 = "A car",
                Option3 = "A Library",
                Option4 = "A framework",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a function?",
                Answer = "A block of code that can be called",
                Option1 = "A block of code that can be called",
                Option2 = "A block of code that can be stored",
                Option3 = "A block of code that can be executed",
                Option4 = "A block of code that can be deleted",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a variable?",
                Answer = "A container for data",
                Option1 = "A container for data",
                Option2 = "A container for methods",
                Option3 = "A container for functions",
                Option4 = "A container for classes",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a method?",
                Answer = "A function inside a class",
                Option1 = "A function inside a class",
                Option2 = "A function inside a method",
                Option3 = "A function inside a variable",
                Option4 = "A function inside a namespace",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a class?",
                Answer = "A blueprint for an object",
                Option1 = "A blueprint for an object",
                Option2 = "A blueprint for a method",
                Option3 = "A blueprint for a function",
                Option4 = "A blueprint for a variable",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a constructor?",
                Answer = "A method that is called when an object is created",
                Option1 = "A method that is called when an object is created",
                Option2 = "A method that is called when a class is created",
                Option3 = "A method that is called when a variable is created",
                Option4 = "A method that is called when a function is created",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a property?",
                Answer = "A value stored inside an object",
                Option1 = "A value stored inside an object",
                Option2 = "A value stored inside a class",
                Option3 = "A value stored inside a method",
                Option4 = "A value stored inside a variable",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a field?",
                Answer = "A value stored inside a class",
                Option1 = "A value stored inside a class",
                Option2 = "A value stored inside an object",
                Option3 = "A value stored inside a method",
                Option4 = "A value stored inside a variable",
                QuizId = 2
            },
            new Question
            {
                Text = "What is a static member?",
                Answer = "A member that belongs to the class, not an object",
                Option1 = "A member that belongs to the class, not an object",
                Option2 = "A member that belongs to the object, not a class",
                Option3 = "A member that belongs to the method, not a class",
                Option4 = "A member that belongs to the variable, not a class",
                QuizId = 2
            },
            new Question {
                Text = "JavaScript is a ___ language.",
                Answer = "Scripting",
                Option1 = "Scripting",
                Option2 = "Programming",
                Option3 = "Markup",
                Option4 = "Styling",
                QuizId = 2
            },
            // HTML
            new Question
            {
                Text = "What is HTML?",
                Answer = "A markup language",
                Option1 = "A markup language",
                Option2 = "A programming language",
                Option3 = "A scripting language",
                Option4 = "A styling language",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a tag?",
                Answer = "An HTML element",
                Option1 = "An HTML element",
                Option2 = "An HTML attribute",
                Option3 = "An HTML value",
                Option4 = "An HTML property",
                QuizId = 3
            },
            new Question
            {
                Text = "What is an attribute?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a value?",
                Answer = "A value of an HTML attribute",
                Option1 = "A value of an HTML attribute",
                Option2 = "A value of an HTML tag",
                Option3 = "A value of an HTML element",
                Option4 = "A value of an HTML property",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a property?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a class?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is an id?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a style?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a script?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            },
            new Question
            {
                Text = "What is a comment?",
                Answer = "A property of an HTML element",
                Option1 = "A property of an HTML element",
                Option2 = "A property of an HTML tag",
                Option3 = "A property of an HTML value",
                Option4 = "A property of an HTML attribute",
                QuizId = 3
            }
            );

        context.SaveChanges();
    }
}
