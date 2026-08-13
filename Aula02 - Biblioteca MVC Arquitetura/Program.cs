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
            Console.WriteLine("-=-=-=-=-=-=  Add Book: -=-=-=-=-=-=");

            Console.SetCursorPosition(2, 1); Console.WriteLine("ISBN : ");
            Console.SetCursorPosition(2, 2); Console.WriteLine("Title : ");
            Console.SetCursorPosition(2, 3); Console.WriteLine("Author : ");
            Console.SetCursorPosition(2, 4); Console.WriteLine("Genre : ");
            Console.SetCursorPosition(2, 5); Console.WriteLine("Pages : ");

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                           
            Console.SetCursorPosition(10, 3); book.Isbn = Console.ReadLine();
            Console.SetCursorPosition(10, 4); book.Title = Console.ReadLine();
            Console.SetCursorPosition(10, 5); book.Author = Console.ReadLine();
            Console.SetCursorPosition(10, 6); book.Genre = Console.ReadLine();
            Console.SetCursorPosition(10, 7); book.Pages = int.Parse(Console.ReadLine());


            Console.SetCursorPosition(8, 10); Console.WriteLine("Book added successfully!");
            Console.SetCursorPosition(8, 11); Console.WriteLine("Press the any key...");
            Console.ReadKey();

            Console.Clear();
            Console.SetCursorPosition(0, 1); Console.WriteLine("-=-=-=-=-=-=  Book Information: -=-=-=-=-=-=");
            Console.SetCursorPosition(0, 2); Console.WriteLine("Book: " + book.Title);


        }
    }
}
