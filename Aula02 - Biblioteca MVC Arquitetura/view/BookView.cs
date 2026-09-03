using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.view
{
    internal class BookView
    {
        private Screen _screen;

        public Screen Screen { get => _screen; set => _screen = value; }

        public BookView()
        {
            this.Screen = new Screen(ConsoleColor.White, ConsoleColor.DarkBlue);
        }

        public void ShowBookMenu()
        {
            Screen.ScreenSetup();
            Screen.FrameAssembly(0, 0, 79, 24);
            Screen.CenterText("Sistema de Biblioteca - Livros", 1, 0, 79);

            Screen.FrameAssembly(1, 2, 30, 10);
            Screen.CenterText("Menu de Livros", 3, 1, 30);

            //opc
            Console.SetCursorPosition(2, 4); Console.WriteLine("1 - Cadastrar Livro");
            Console.SetCursorPosition(2, 5); Console.WriteLine("2 - Listar Livros");
            Console.SetCursorPosition(2, 6); Console.WriteLine("3 - Buscar Livro");
            Console.SetCursorPosition(2, 7); Console.WriteLine("4 - Atualizar Livro");
            Console.SetCursorPosition(2, 8); Console.WriteLine("5 - Deletar Livro");
            Console.SetCursorPosition(2, 9); Console.WriteLine("0 - Voltar ao Menu Principal");
            Console.SetCursorPosition(2, 10); Console.WriteLine("Escolha uma opção: ");
        }
    }
}