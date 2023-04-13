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

        /// <summary>
        /// Used to allow per-book sorting AND SortByAuthor
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Book other)
        {
            return this.Author.CompareTo(other.Author);
        }


        ////public int CompareTo(Book other)
        //{
        //    if (other == null)
        //        return 1;

        //    string[] myName = this.Author.Split(' ');
        //    string[] otherName = other.Author.Split(' ');
        //    // by using a call to base CompareTo, 
        //    // we don't need to worry about specifying -1, 0, or 1

        //    // return N < 0 if 'this' precedes 'other'
        //    if(myName[1].CompareTo(otherName[1]) < 0)
        //    {
        //        return myName[1].CompareTo(otherName[1]);
        //    }

        //    // return 0 if the two are the same
        //    if (myName[1].CompareTo(otherName[1]) == 0)
        //    {
        //        return myName[1].CompareTo(otherName[1]);

        //    }

        //    // return N > 1 'other' precedes 'this'
        //    if (myName[1].CompareTo(otherName[1]) > 0)
        //        {
        //        return myName[1].CompareTo(otherName[1]);

        //    }
        //}
    }
}
