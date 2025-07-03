using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_proj
{
    internal class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string category { get; set; }

        public bool available = true;

        public Book(){}
        public Book(string title, string author, string category)
        {
            this.title = title;
            this.author = author;
            this.category = category;
        }
    }
}
