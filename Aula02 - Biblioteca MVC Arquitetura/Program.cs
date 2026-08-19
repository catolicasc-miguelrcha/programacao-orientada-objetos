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
            // BookModel book = new BookModel("1", "Fundamentos da arquitetura de software: uma abordagem de engenharia", "Mark Richards, Neal Ford", "O'REILLY", "IT", false);
            // Display book information, always (10, X) position
            // Console.SetCursorPosition(10, 5);
            // Console.WriteLine("Book: " + book.title);

            BookModel book = new BookModel();

            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=     Add Book:   -=-=-=-=-=-=-");
            Console.WriteLine("ISBN : ");
            Console.WriteLine("Title : ");
            Console.WriteLine("Author : ");
            Console.WriteLine("Genre : ");
            Console.WriteLine("Pages : ");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                           
            book.Isbn = Console.ReadLine();
            book.Title = Console.ReadLine();
            book.Author = Console.ReadLine();
            book.Genre = Console.ReadLine();
            book.Pages = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Book added successfully!");
            Console.WriteLine("Press the any key...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=  Book Information: -=-=-=-=-=-=");
            Console.WriteLine("Book: " + book.Title);


        }
    }
}
