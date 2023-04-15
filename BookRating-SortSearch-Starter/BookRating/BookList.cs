using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        public List<Book> SortedByAuthor(bool sortDirection = false)
        {
            allBooks.Sort();

            if (!sortDirection)
            {
                // List<T>.Sort() always sorts Ascending, so if we need to flip it...
                allBooks.Reverse();
            }
            return allBooks;
        }

        public List<Book> AboveRating(double rating, string targetAuthor)
        {
            // Return an Enumerable eq
            allBooks.Where(book =>
                book.Author == targetAuthor).ToList();


            return allBooks.Where(b =>
            b.Rating >= rating).ToList();
        }

        public List<Book> SortedByAuthorYear(bool sortDirection)
        {
            // Bet you didn't think we could do this in one line!
            List<Book> sortedList = allBooks.OrderBy(book => book.Author).ThenBy(book => book.Year).ToList();
            return sortedList;
            /**
            allBooks = SortedByAuthor(sortDirection);
            // do we need to implement another CompareTo that uses year instead of the 
            //EqualityComparer<Book>.Default

            SortByAuthor(sortDirection);

            // organize by the year
            HashSet<char> startsWith = new HashSet<char>();
            // count of books by this letter, the letter in question

            // use a bucket for each letter we have in the table...
            allBooks.ForEach(b => startsWith.Add(b.Author[0]));

            // now, we can just sort each "bucket" by year!
            int greatestYear = int.MinValue; */
        }

        private void SortByYear(bool sortDirection = false)
        {
            for (int i = 1; i < allBooks.Count; i++)
            {
                // if the i-th book was published more recently than book at index 0..
                if (sortDirection)
                {

                    // Take the largest year between 0-th year and i-th year
                    if (Math.Min(allBooks[i].Year, allBooks[0].Year) == allBooks[i].Year)
                    {
                        /// update it
                        Book temp = allBooks[0];
                        allBooks[0] = allBooks[i];
                        allBooks[i] = temp;
                    }

                }
                else
                {
                    if (allBooks[i].Year < allBooks[0].Year)
                    {
                        /// update it
                        Book temp = allBooks[0];
                        allBooks[0] = allBooks[i];
                        allBooks[i] = temp;
                    }

                }

            }
        }

        private void SortByAuthor(bool sortDirection)
        {

            for (int i = 1; i < allBooks.Count; i++)
            {
                if (sortDirection)
                {
                    if (allBooks[i].Author.CompareTo(allBooks[0].Author) == -1)
                    {
                        Book temp = allBooks[i];
                        allBooks[0] = allBooks[i];
                        allBooks[i] = temp;
                    }
                }
                else
                {
                    if (allBooks[i].Author.CompareTo(allBooks[0].Author) == 1)
                    {
                        Book temp = allBooks[i];
                        allBooks[0] = allBooks[i];
                        allBooks[i] = temp;
                    }
                }

            }
        }
    }
}