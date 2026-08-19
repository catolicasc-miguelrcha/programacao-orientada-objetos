using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.view
{
    internal class Screen
    {
        private ConsoleColor _textColor;
        private ConsoleColor _backgroundColor;

        public ConsoleColor TextColor { get => _textColor; set => _textColor = value; }
        public ConsoleColor BackgroundColor { get => _backgroundColor; set => _backgroundColor = value; }
    
    public Screen()
    {
            this.TextColor = ConsoleColor.Green;    
            this.BackgroundColor = ConsoleColor.Black;
    }

    public Screen(ConsoleColor textColor, ConsoleColor backgroundColor)
    {
            this.TextColor = text;
            this.BackgroundColor = background;
    }

    public void CenterText(string text, int line, int y, int x)
    {
        // power apps formmula 
            int column = y + ((x-y-text.Length) / 2);
            Conosole.SetCursorPosition(column, line);
            Console.WriteLine(text);
    }

    public string Ask(string text, int line, int column)
    {
        string answer = "";

        Console.SetCursorPosition(column, line);
        Console.Write(text);
        answer = Console.ReadLine();

        return answer;

    }



    }
}
