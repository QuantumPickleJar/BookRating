using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating
{
    public class BookList
    {
        private List<Book> allBooks;

        public BookList()
        {
            allBooks = new List<Book>();
        }
        public void AddBook(Book book)
        {
            allBooks.Add(book);
        }

        public int NumberBooks()
        {
            return allBooks.Count;
        }

        public double HighestRating()
        {
            double result = 0.0;
            foreach (Book b in allBooks)
            {
                if (b.Rating > result)
                    result = b.Rating;
            }
            return result;
        }

        public double RatingByAuthor(string author)
        {
            double result = -1;
            double sum = 0;
            int count = 0;
            foreach (Book b in allBooks)
            {
                if (b.Author.Equals(author))
                {
                    count++;
                    sum += b.Rating;
                }
                if (count > 0)
                    result = sum / count;
            }
            return result;
        }
        public void RemoveBook(Book book)
        {
            allBooks.Remove(book);
        }

        public double AverageRating()
        {
            double result = -1;
            double sum = 0;
            foreach (Book b in allBooks)
            {
                sum += b.Rating;
            }
            result = sum / allBooks.Count;
            return result;
        }

        public void RemoveBook(int year)
        {
            List<Book> removeList = new List<Book>(); //list to hold search results
            foreach (Book b in allBooks)
            {
                if (b.Year == year) //we have a hit!
                {
                    //allBooks.Remove(b); //can't remove inside loop
                    removeList.Add(b); //add search result to the list
                }
            }

            foreach (Book b in removeList) //go through each element in the search results
            {
                allBooks.Remove(b); //...and remove from the original list
            }
            //Alternative to last foreach loop:
            // allBooks = allBooks.Except(removeList).ToList();
        }

        public void RemoveLastAdded()
        {
            allBooks.RemoveAt(allBooks.Count - 1);
        }

        public bool ContainsBook(Book book)
        {
            return allBooks.Contains(book);
        }

        public Book OldestBook()
        {
            Book oldestBook = allBooks[0];
            foreach (Book b in allBooks)
            {
                if (b.Year < oldestBook.Year)
                    oldestBook = b;
            }
            return oldestBook;
        }

        public object YoungestBook()
        {
            Book youngestBook = allBooks[0];
            foreach (Book b in allBooks)
            {
                if (b.Year > youngestBook.Year)
                    youngestBook = b;
            }
            return youngestBook;
        }

        public List<Book> SortedByAuthor(bool sortDirection)
        {
            throw new NotImplementedException();
        }

         

        public List<Book> AboveRating(double rating)
        {
            throw new NotImplementedException();
        }

        public List<Book> SortedByAuthorYear(bool sortDirection)
        {
            throw new NotImplementedException();
        }
    }
}
