using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.model
{
    // Atributes of the book
    internal class BookModel
    {
        private String _isbn;
        private String _title;
        private String _author;
        private String _publisher;
        private String _genre;
        private bool _borrowed;
        private int _pages;


        // Properties for each attribute
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string Title { get => _title; set => _title = value; }
        public string Author { get => _author; set => _author = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public bool Borrowed { get => _borrowed; set => _borrowed = value; }
        public int Pages { get => _pages; set => _pages = value; }

        // Method construct (get and set in java)
        public BookModel(string Isbn, string Title, string Author, string Genre, int Pages, bool Borrowed)
        {
            this.Isbn = Isbn;
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.Pages = Pages;
            this.Borrowed = Borrowed;
        }
                        
        // Method construct null
        public BookModel()
        {
            this.Isbn = "";
            this.Title = "";
            this.Author = "";
            this.Genre = "";
            this.Pages = 0;
            this.Borrowed = false;
        }


    }
}
