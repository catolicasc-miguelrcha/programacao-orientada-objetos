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
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
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
 
            this._colIni = 22;
            this._linIni = 2;
            this._colFin = _colIni + this._campos[0].Length + 1 + 30;
            // +1 para colocar o traçado vertical direito depois dos :
            // +30 para ter espaço para o usuário digitar os dados
            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Titulo e um espaço para perguntas
            this._colDados = this._colIni + this._campos[0].Length + 1;
            this._linDados = this._linIni + 2;
        }
 
        public void MostrarFormulario()
        {
            
            Tela tela = new Tela();
            tela.MontarMoldura(
                this._colIni, this._linIni, 
                this._colFin, this._linFin, 
                "Cadastro de Livros"
            );
            
 
            int linha = this._linIni + 2;
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni+1, linha);
                Console.Write(campo);
                linha++;
            }
        }
 
 
        public LivroModel EntrarDados(string qual)
        {
            LivroModel obj = new LivroModel();
            
 
            if (qual == "PK")
            {
                // pergunta a chave primária (código)
                Console.SetCursorPosition(this._colDados,  this._linDados);
                obj.Isbn = Console.ReadLine();
            }
            else
            {
                // pergunta todos os outros dados
                for (int i = 1; i < this._campos.Count; i++)
                {
                    Console.SetCursorPosition(_colDados, this._linDados + i);
                    Console.ReadLine();
                }
            }
 
            return obj;
        }
 
 
    }
}