using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_proj
{
    internal class Library_Manager
    {
        public static Dictionary<int, Book> Books = new Dictionary<int, Book>();
       public static  SortedList<string, List<Book>> BookAuthor = new SortedList<string, List<Book>>(); //Books sorted by author 
        public static int bookId = 0;
       
        public void AddBook(Book book)
        {
            book.id = ++bookId;
            
            Books.Add(book.id, book);
            if (BookAuthor.ContainsKey(book.author))
            {
                BookAuthor[book.author].Add(book);
            }
            else
            {
                BookAuthor.Add(book.author, new List<Book> { book });
            }
            Console.WriteLine("New book was Added.");
        }
        public void RemoveBook(Book book)
        {
            var bookToRemove = Books.Values.FirstOrDefault(b => b.title == book.title);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove.id);
                foreach (var b in BookAuthor[bookToRemove.author])
                {
                    if (b.title == bookToRemove.title)
                    {
                        BookAuthor[bookToRemove.author].Remove(b);
                        if (BookAuthor[bookToRemove.author].Count == 0)
                        {
                            BookAuthor.Remove(bookToRemove.author);
                            break;
                        }

                    }
                }
            }
            Console.WriteLine($"{book.title} has been Removed.");
        }
        }
    }
    
