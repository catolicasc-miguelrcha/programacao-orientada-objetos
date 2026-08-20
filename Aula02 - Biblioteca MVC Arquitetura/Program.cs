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

            Screen screen = new Screen(ConsoleColor.Green, ConsoleColor.Blue);

            screen.ScreenSetup();
            screen.FrameAssembly(0, 0, 79, 24);
            screen.CenterText("Sistema de Biblioteca", 1, 0, 79);

            screen.FrameAssembly(5, 3, 30, 10);
            screen.CenterText("[1] Cadastrar Livro", 4, 5, 30);

            screen.FrameAssembly(40, 10, 75, 23);
            screen.CenterText("Lista de Livros", 11, 40, 75);

            // popup
            screen.FrameAssembly(40, 10, 75, 23);
            screen.CenterText("Avisos importantes", 8, 20, 60);

            Console.ReadKey();

            // BookModel book = new BookModel();

            // Console.Clear();
            // Console.WriteLine("-=-=-=-=-=-=     Add Book:   -=-=-=-=-=-=-");
            // Console.WriteLine("ISBN : ");
            // Console.WriteLine("Title : ");
            // Console.WriteLine("Author : ");
            // Console.WriteLine("Genre : ");
            // Console.WriteLine("Pages : ");
            // Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                           
            // book.Isbn = Console.ReadLine();
            // book.Title = Console.ReadLine();
            // book.Author = Console.ReadLine();
            // book.Genre = Console.ReadLine();
            // book.Pages = int.Parse(Console.ReadLine());
            // Console.Clear();

            // Console.WriteLine("Book added successfully!");
            // Console.WriteLine("Press the any key...");
            // Console.ReadKey();

            // Console.Clear();
            // Console.WriteLine("-=-=-=-=-=-=  Book Information: -=-=-=-=-=-=");
            // Console.WriteLine("Book: " + book.Title);


        }
    }
}
