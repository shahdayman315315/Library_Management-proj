namespace Library_Management_proj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book() {  title= "Book1", author= "Mohamed" ,category= "scientific" };
            Book b2 = new Book() { title = "Book2", author = "Ali", category = "Adventure" };
            Book b3 = new Book() { title = "Book3", author = "Salah", category = "imaginary" };
            Library_Manager library_Manager = new Library_Manager();
            library_Manager.AddBook(b1);
            library_Manager.AddBook(b2);
            library_Manager.AddBook(b3);

            Loan_Manager loan_Manager = new Loan_Manager();
            loan_Manager.BorrowBook("Book1", "Noor");
            loan_Manager.BorrowBook("Book2", "Ahmed");
             library_Manager.RemoveBook(b3);
            loan_Manager.BorrowBook("Book3", "Sara");
            string name=loan_Manager.GetBorrower("Book1");
            Console.WriteLine("Borrowers of Book1: " + name);
            loan_Manager.BorrowBook("Book1", "sara");
            loan_Manager.ReturnBook("Book1");
            loan_Manager.BorrowBook("Book2", "Hassan");
            loan_Manager.BorrowBook("Book2", "Omar");
            loan_Manager.ReturnBook("Book2");
            loan_Manager.ReturnBook("Book2");
            loan_Manager.ReturnBook("Book2");

        }
    }
}
