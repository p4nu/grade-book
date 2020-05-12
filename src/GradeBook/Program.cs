using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = EnterBookName();

            EnterGrades(book);

            book.GetStatistics();
            book.ShowStatistics();
        }

        private static IBook EnterBookName()
        {
            IBook book;
            while (true)
            {
                Console.WriteLine("Please enter a book's name.");
                var input = Console.ReadLine();

                try
                {
                    book = new InMemoryBook(input);
                    book.GradeAdded += OnGradeAdded;
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return book;
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input.StartsWith('q'))
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
