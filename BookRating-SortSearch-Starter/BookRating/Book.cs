using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public double Rating { get; private set; }

        public Book(string title, string author, int year, double rating)
        {
            Title = title;
            Author = author;
            Year = year;
            Rating = rating;
        }

        public int CompareTo(Book other)
        {
            return Author.CompareTo(other.Author);
        }
    }
}
