using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating
{
    [TestClass()]
    public class BookTests
    {
        BookList books;
        Book b1, b2, b3, b4, b5, b6, b7, b8, b9, b10;


        [TestInitialize]
        public void SetUp()
        {
            b1 = new Book("A Tale of Two cities", "Charles Dickens", 1859, 3.76);
            b2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, 3.85);
            b3 = new Book("Pride and Prejudice", "Jane Austen", 1813, 4.23);
            b4 = new Book("To Kill a Mockingbird", "Harper Lee", 1960, 4.23);
            b5 = new Book("Jane Eyre", "Charlotte Bronte", 1847, 4.07);
            b6 = new Book("The Catcher in the Rye", "J.D. Salinger", 1951, 3.77);
            b7 = new Book("Sense and Sensibility", "Jane Austen", 1811, 4.04);
            b8 = new Book("Emma", "Jane Austen", 1815, 3.97);
            b9 = new Book("1984", "George Orwell", 1949, 4.09);
            b10 = new Book("Oliver Twist", "Charles Dickens", 1838, 3.82);

            books = new BookList();
            books.AddBook(b1);
            books.AddBook(b2);
            books.AddBook(b3);
            books.AddBook(b4);
            books.AddBook(b5);
            books.AddBook(b6);
            books.AddBook(b7);
            books.AddBook(b8);
            books.AddBook(b9);
            books.AddBook(b10);


        }
        [TestMethod]
        public void BooksAddedTest()
        {
            Assert.AreEqual(10, books.NumberBooks());
            books.AddBook(new Book("Frankenstein", "Mary Shelley", 1818, 3.76));
            Assert.AreEqual(11, books.NumberBooks());

        }

        [TestMethod]
        public void HighestRatingTest()
        {
            Assert.AreEqual(4.23, books.HighestRating());
        }

        [TestMethod]
        public void RemoveBookTest()
        {
            books.RemoveBook(b5);
            Assert.AreEqual(9, books.NumberBooks());
        }

        [TestMethod]
        public void RemoveBookByYearTest()
        {
            books.RemoveBook(1815);
            Assert.AreEqual(9, books.NumberBooks());
        }


        [TestMethod]
        public void RemoveLastAddTest()
        {
            books.RemoveLastAdded();
            Assert.IsFalse(books.ContainsBook(b10));
        }
        [TestMethod]
        public void AverageRatingTest()
        {
            Assert.AreEqual(3.98, books.AverageRating(), .005);
        }

        [TestMethod]
        public void AverageByAuthorTest()
        {
            Assert.AreEqual((4.23 + 4.04 + 3.97) / 3.0, books.RatingByAuthor("Jane Austen"));
            Assert.AreEqual(-1, books.RatingByAuthor("Jakob Iversen")); //Author doesn't exist in the list of books
        }

        [TestMethod]
        public void OldestBookTest()
        {
            Assert.AreSame(b7, books.OldestBook());
        }

        [TestMethod]
        public void YoungestBookTest()
        {
            Assert.AreSame(b4, books.YoungestBook());
        }

        [TestMethod]
        public void SortByAuthorTest()
        {
            List<Book> booksByAuthor = new List<Book> { b1, b10, b5, b2, b9, b4, b6, b3, b7, b8 };
            List<Book> booksByAuthorReverse = new List<Book> { b8, b7, b3, b6, b4, b9, b2, b5, b10, b1 };
            CollectionAssert.AreEqual(booksByAuthor, books.SortedByAuthor(true)); //ascending sort
            CollectionAssert.AreEqual(booksByAuthorReverse, books.SortedByAuthor(false)); //descending sort
        }

        [TestMethod]
        public void SortByAuthorYearTest()
        {
            List<Book> booksByAuthorYear = new List<Book> { b10, b1, b5, b2, b9, b4, b6, b7, b3, b8 };
            CollectionAssert.AreEqual(booksByAuthorYear, books.SortedByAuthorYear(true));
        }

        [TestMethod]
        public void FourPlusTest()
        {
            List<Book> fourPlus = new List<Book> { b3, b4, b5, b7, b9 };
            CollectionAssert.AreEquivalent(fourPlus, books.AboveRating(4.0));
        }
    }
}