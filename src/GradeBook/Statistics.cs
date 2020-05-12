using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average {
            get
            {
                if (count > 0)
                {
                    return sum / count;
                }
                return 0.0;
            }
        }
        public double Low;
        public double High;
        public char Letter {
            get
            {
                return Average switch
                {
                    var d when d >= 90.0 => 'A',
                    var d when d >= 80.0 => 'B',
                    var d when d >= 70.0 => 'C',
                    var d when d >= 60.0 => 'D',
                    _ => 'F',
                };
            }
        }
        int count;
        double sum;

        public Statistics()
        {
            count = 0;
            sum = 0.0;
            High = 0.0;
            Low = 0.0;
        }

        internal void Add(double number)
        {
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
            sum += number;
            count++;
        }
    }
}
