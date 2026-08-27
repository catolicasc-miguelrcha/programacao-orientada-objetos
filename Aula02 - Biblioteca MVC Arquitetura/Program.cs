using Biblioteca.model;
using Biblioteca.controller;
using Biblioteca.view;
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

            Screen screen = new Screen(ConsoleColor.Magenta, ConsoleColor.Cyan);
            BookController bookController = new BookController();

            while (true)
            {
                screen.ScreenSetup();
                screen.FrameAssembly(0, 0, 79, 24);
                screen.CenterText("Sistema de Biblioteca", 1, 0, 79);


                screen.FrameAssembly(1, 2, 30, 10);
                screen.CenterText("Menu", 3, 1, 30);

                //opc
                Console.SetCursorPosition(2, 4); Console.WriteLine("1 - Livros");
                Console.SetCursorPosition(2, 5); Console.WriteLine("2 - Alunos");
                Console.SetCursorPosition(2, 6); Console.WriteLine("3 - Emprestimos");
                Console.SetCursorPosition(2, 7); Console.WriteLine("4 - Relatorios");
                Console.SetCursorPosition(2, 8); Console.WriteLine("0 - Sair");
                Console.SetCursorPosition(2, 9); Console.WriteLine("Escolha uma opção: ");
                string opc = Console.ReadLine();

                if (opc == "0") { screen.CenterText("Saindo do sistema... Acione uma tecla para continuar...", 23, 0, 79); Console.ReadKey(); break; }
                else if (opc == "1") { bookController.RunExcecution(); }
                else if (opc == "2") { }
                else if (opc == "3") { }
                else if (opc == "4") { }
                else { screen.CenterText("Opção inválida! Acione uma tecla para continuar...", 23, 0, 79); }

                Console.ReadKey();
            }

        }
    }
}
