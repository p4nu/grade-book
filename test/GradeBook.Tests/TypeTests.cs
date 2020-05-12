using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            // log = new WriteLogDelegate(ReturnMessage);
            log = ReturnMessage;

            var result = log("Hello!");

            Assert.Equal("Hello!", result);
        }

        [Fact]
        public void WriteLogDelegateCanPointToMultipleMethods()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");

            Assert.Equal(3, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(2, x);
        }

        void SetInt(ref int x)
        {
            x = 2;
        }

        int GetInt()
        {
            return 1;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
