using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.view;

namespace Biblioteca.controller
{
    internal class BookController
    {
        // atributos
        private int _column;
        private int _line; //row 
        private string _title;

        public BookController()
        {
        }

        // propriedades

        // metodos

        public BookController(int column, int line)
        {
            this._column = 20;
            this._line = 5;
            this._title = "Controle de Livros";
        }


        public void RunExcecution()
        {
            Screen bookScreen = new Screen();
            bookScreen.FrameAssembly(
                this._column,
                this._line,
                this._column + 40,
                this._line + 10
                );
            bookScreen.CenterText(
                this._title,
                this._line + 1,
                this._column,
                this._column + 40
                );
            Console.ReadKey();
        }

    }
}
