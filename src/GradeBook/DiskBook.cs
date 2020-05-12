using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using var streamWriter = File.AppendText($"{Name}.txt");
            streamWriter.WriteLine(grade);

            GradeAdded?.Invoke(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            using var streamReader = File.OpenText($"{Name}.txt");
            var gradeText = "";

            if (streamReader.ReadLine() == null)
            {
                return statistics;
            }
            streamReader.DiscardBufferedData(); // resetting streamReader position
            streamReader.BaseStream.Position = 0;

            statistics.High = double.MinValue;
            statistics.Low = double.MaxValue;

            while ((gradeText = streamReader.ReadLine()) != null)
            {
                statistics.Add(double.Parse(gradeText));
            }

            return statistics;
        }
    }
}
