using System;
using Xunit;

namespace GradeBook.Tests
{
    public class InMemoryBookTests
    {
        [Fact]
        public void BookGetsAName()
        {
            var book = new InMemoryBook("Booky");

            Assert.Equal("Booky", book.Name);
        }

        [Fact]
        public void BookCalculatesStatistics()
        {
            // arrange
            var book = new InMemoryBook("Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void InvalidGradesThrowAnArgumentException()
        {
            var book = new InMemoryBook("Book");

            Assert.Throws<ArgumentException>(() => book.AddGrade(105));
            Assert.Throws<ArgumentException>(() => book.AddGrade(-1));
        }

        [Fact]
        public void HundredAndZeroValuesAddedToStatistics()
        {
            var book = new InMemoryBook("Book");
            book.AddGrade(0);
            book.AddGrade(100);

            Assert.Contains(0, book.Grades);
            Assert.Contains(100, book.Grades);
        }

        [Fact]
        public void StatisticsShownCorrectlyOnEmptyStats()
        {
            var book = new InMemoryBook("Empty Statistics");

            var result = book.GetStatistics();

            Assert.Equal(0, result.Low);
            Assert.Equal(0, result.High);
            Assert.Equal(0, result.Average);
        }

        [Fact]
        public void EmptyBookNameReturnsArgumentException()
        {
            var book = new InMemoryBook("Something");

            Assert.Throws<ArgumentException>(() => book.Name = "");
        }
    }
}
