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
            int column = y + ((x - y - text.Length) / 2);
            Console.SetCursorPosition(column, line);
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

        public void FrameAssembly(int line, int column, int width, int height)
        {
            int Column, Line;


            for (Column = column; Column < column + width; Column++)
            {
                Console.SetCursorPosition(Column, line);
                Console.Write("="); // 205
                Console.SetCursorPosition(Column, line + height);
                Console.Write("="); // 205
            }

            for (Line = line; Line < line + height; Line++)
            {
                Console.SetCursorPosition(column, Line);
                Console.Write("|"); // 186
                Console.SetCursorPosition(column + width, Line);
                Console.Write("|"); // 186
            }


            Console.SetCursorPosition(column, line);
            Console.Write("+");
            Console.SetCursorPosition(column, line);
            Console.Write("+");
            Console.SetCursorPosition(line, column);
            Console.Write("+");
            Console.SetCursorPosition(line, column);
            Console.Write("+");
        }

        public void ScreenSetup()
        {
            Console.ForegroundColor = this.TextColor;
            Console.BackgroundColor = this.BackgroundColor;
            Console.Clear();


        }


        public void ClearScreen(int line, int column, int width, int height)
        {
            for (int l = line; l < line + height; l++)
            {
                for (int c = column; c < column + width; c++)
                {
                    Console.SetCursorPosition(c, l);
                    Console.Write(" ");
                }
            }
        }

    }
}
