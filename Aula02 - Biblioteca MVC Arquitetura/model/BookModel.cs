using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.model
{
    // Model class for Book
    internal class BookModel
    {
        public String ISBN;
        public String title;
        public String author;
        public String publisher;
        public String genre;
        public bool borrowed;


        // Method
        
        public BookModel(String ISBN, String title, String author, String publisher, String genre, bool borrowed)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.genre = genre;
            this.borrowed = false;
        }

    }
}
