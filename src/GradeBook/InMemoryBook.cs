using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
        public List<double> Grades { get; }

        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}.");
            }
        }

        public override Statistics GetStatistics()
        {
            if (Grades.Count == 0)
            {
                return statistics;
            }

            statistics.High = double.MinValue;
            statistics.Low = double.MaxValue;

            for (var index = 0; index < Grades.Count; index++)
            {
                statistics.Add(Grades[index]);
            }

            return statistics;
        }
    }
}
