using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_proj
{
    internal class Loan_Manager
    {
         Dictionary<string,string> current_loans = new Dictionary<string, string>();
         Dictionary<string,Queue<string>> waitng_lists = new Dictionary<string, Queue<string>>();

        public Loan_Manager()
        {
             
            Console.WriteLine("Available Books : ");
            foreach (var book in Library_Manager.BookAuthor)
            {
                Console.WriteLine("Author: " + book.Key);
                foreach (var b in book.Value)
                {
                    Console.Write(b.title + " ");
                }
                Console.WriteLine();
            }

        
        }
        public void BorrowBook(string book_name, string Borrower_name)
        {
            var book = Library_Manager.Books.Values.FirstOrDefault(b => b.title == book_name);
            if (book != null)
            {
                if (book.available)
                {
                    book.available = false;
                    current_loans.Add(book_name, Borrower_name);
                    Console.WriteLine($"{book_name} currently Borrowed by {Borrower_name}");
                }
                else
                {
                    if (!waitng_lists.ContainsKey(book_name))
                    {
                        waitng_lists.Add(book_name, new Queue<string>());
                        waitng_lists[book_name].Enqueue(Borrower_name);
                    }
                    else
                    {
                        waitng_lists[book_name].Enqueue(Borrower_name);
                    }
                    Console.WriteLine("This Book is Not Available Now ,please wait your role.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        public void ReturnBook(string book_name)
        {
            current_loans.Remove(book_name);

            if (waitng_lists.ContainsKey(book_name))
            {
                string next_borrower=waitng_lists[book_name].Dequeue();
                if (waitng_lists[book_name].Count == 0)
                {
                    waitng_lists.Remove(book_name);
                }
                current_loans.Add(book_name, next_borrower);
                Console.WriteLine($"{book_name} currently Borrowed by {next_borrower}");

            }
            else
            {
                var book = Library_Manager.Books.Values.FirstOrDefault(b => b.title == book_name);
                book.available = true;
                Console.WriteLine($"{book_name} has been returned");
            }
        }
        public string GetBorrower(string book_name)
        {
            if(current_loans.ContainsKey(book_name))
            {
                return current_loans[book_name];
            }
            else
            {
                return "No borrower found for this book.";
            }
        }
        
    }
}
