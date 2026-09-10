using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.view
{
    internal class LivroView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin;
        private List<string> _campos;

        // construtor
        public LivroView()
        {
            this._campos = new List<string>();
            this._campos.Add("ISBN    :");
            this._campos.Add("Título  :");
            this._campos.Add("Autor   :");
            this._campos.Add("Gênero  :");
            this._campos.Add("Páginas :");

            this._colIni = 20;
            this._linIni = 5;
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;
            this._linFin = _linIni + this._campos.Count + 1;
        }

        public void mostrarFormulario()
        {
            Tela tela = new Tela();
            tela.montarMoldura(this._colIni, this._linIni, this._colFin, this._linFin, "Cadastro de Livro");

            int linha = this._linIni + 2;

            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(campo);
                linha++;
            }
        }
    }
}
