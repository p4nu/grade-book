using System;
using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        internal readonly Statistics statistics;

        public Book(string name) : base(name)
        {
            statistics = new Statistics();
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            Console.WriteLine($"Book name: {Name}");
            Console.WriteLine($"The average grade is {statistics.Average:N1}.");
            Console.WriteLine($"The highest grade is {statistics.High}.");
            Console.WriteLine($"The lowest grade is {statistics.Low}.");
            Console.WriteLine($"The letter grade is {statistics.Letter}.");
        }
    }
}
