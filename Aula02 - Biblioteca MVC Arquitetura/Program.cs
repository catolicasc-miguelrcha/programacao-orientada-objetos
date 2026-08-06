using Biblioteca.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    // func principal para start app
    internal class Program
    {
        static void Main(string[] args)
        {
            BookModel book = new BookModel();

            book.ISBN = "1";
            book.title = "Fundamentos da arquitetura de software: uma abordagem de engenharia";
            book.author = "Mark Richards, Neal Ford";
            book.publisher = "O'REILLY";
            book.genre = "IT";
            book.borrowed = false;

            book.ISBN = "2";
            book.title = "Clean Code: A Handbook of Agile Software Craftsmanship";
            book.author = "Robert C. Martin";
            book.publisher = "Prentice Hall";
            book.genre = "IT";
            book.borrowed = false;


            // Display book information, always (10, X) position
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("Book: " + book.title);
            


        }
    }
}
