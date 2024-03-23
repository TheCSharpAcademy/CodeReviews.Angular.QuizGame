using QuizGameAPI.Models;

namespace QuizGameAPI.Database;

public class SeedDatabase
{
    public static void Seed(QuizContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Quizzes.Any())
        {
            context.Quizzes.AddRange(
                new Quiz
                {
                    Name = "Maths"
                },
                new Quiz
                {
                    Name = "Buffy"
                },
                new Quiz
                {
                    Name = "Cats"
                }
            );
            
            context.SaveChangesAsync();
        }
        var mathsId = context.Quizzes.FirstOrDefault(q => q.Name == "Maths")!.Id;
        var buffyId = context.Quizzes.FirstOrDefault(q => q.Name == "Buffy")!.Id;
        var catsId = context.Quizzes.FirstOrDefault(q => q.Name == "Cats")!.Id;

        if (!context.Questions.Any())
        {
            context.Questions.AddRange(
                new Question
                {
                    QuestionPrompt = "What is 11 x 11",
                    Answer1 = "121",
                    Answer2 = "111",
                    Answer3 = "112",
                    CorrectAnswer = 1,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is 18 divided by 3",
                    Answer1 = "9",
                    Answer2 = "3",
                    Answer3 = "6",
                    CorrectAnswer = 3,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is 99 minus 35",
                    Answer1 = "66",
                    Answer2 = "62",
                    Answer3 = "64",
                    CorrectAnswer = 3,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is the square root of 64",
                    Answer1 = "6",
                    Answer2 = "8",
                    Answer3 = "12",
                    CorrectAnswer = 2,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is pi",
                    Answer1 = "4.15",
                    Answer2 = "3.14",
                    Answer3 = "tasty",
                    CorrectAnswer = 2,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is cos(90)?",
                    Answer1 = "0",
                    Answer2 = "pi",
                    Answer3 = "infinity",
                    CorrectAnswer = 2,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is 5 squared",
                    Answer1 = "25",
                    Answer2 = "50",
                    Answer3 = "500",
                    CorrectAnswer = 1,
                    QuizId = mathsId
                },
                new Question
                {
                    QuestionPrompt = "What is Buffy's middle name",
                    Answer1 = "Amy",
                    Answer2 = "Anne",
                    Answer3 = "Maria",
                    CorrectAnswer = 2,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "What is Spike's real name",
                    Answer1 = "William",
                    Answer2 = "Andrew",
                    Answer3 = "Spike",
                    CorrectAnswer = 1,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "In which town is Buffy set?",
                    Answer1 = "Sunnydale",
                    Answer2 = "Springfield",
                    Answer3 = "Smallville",
                    CorrectAnswer = 1,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "How many episodes of Buffy were made",
                    Answer1 = "108",
                    Answer2 = "132",
                    Answer3 = "144",
                    CorrectAnswer = 3,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "When did Buffy first air on TV?",
                    Answer1 = "1996",
                    Answer2 = "1997",
                    Answer3 = "1997",
                    CorrectAnswer = 2,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "Who is Ripper?",
                    Answer1 = "Rupert Giles",
                    Answer2 = "Ethan Rayne",
                    Answer3 = "Angel",
                    CorrectAnswer = 1,
                    QuizId = buffyId
                },
                new Question
                {
                    QuestionPrompt = "What colour eyes are cats born with?",
                    Answer1 = "Blue",
                    Answer2 = "Green",
                    Answer3 = "Brown",
                    CorrectAnswer = 1,
                    QuizId = catsId
                },
                new Question
                {
                    QuestionPrompt = "What gender are tortoiseshell cats?",
                    Answer1 = "Almost always female",
                    Answer2 = "Almost always male",
                    Answer3 = "Whatever they want to be",
                    CorrectAnswer = 1,
                    QuizId = catsId
                },
                new Question
                {
                    QuestionPrompt = "What is the scientific name for catnip",
                    Answer1 = "Nepeta Cataria",
                    Answer2 = "Scogetta Cataria",
                    Answer3 = "Cocoaenia Cateria",
                    CorrectAnswer = 1,
                    QuizId = catsId
                },
                new Question
                {
                    QuestionPrompt = "What is a fear of cats called",
                    Answer1 = "Ailurophobia",
                    Answer2 = "Feliophobia",
                    Answer3 = "Feliusphobia",
                    CorrectAnswer = 1,
                    QuizId = catsId
                },
                new Question
                {
                    QuestionPrompt = "Approximately how many years have people been keeping cats as pets?",
                    Answer1 = "9000",
                    Answer2 = "8500",
                    Answer3 = "9500",
                    CorrectAnswer = 3,
                    QuizId = catsId
                },
                new Question
                {
                    QuestionPrompt = "What is the collective term for a group of cats?",
                    Answer1 = "Clowder",
                    Answer2 = "Pack",
                    Answer3 = "Clan",
                    CorrectAnswer = 1,
                    QuizId = catsId
                }
                );
            context.SaveChangesAsync();
        }
    }
}