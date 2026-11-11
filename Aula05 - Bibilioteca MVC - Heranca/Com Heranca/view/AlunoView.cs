using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    // heranca
    internal class AlunoView : Tela
    {
        // atributos
        // (_colIni, _linIni, _colFin e _linFin são herdados de Tela)
        private int _colDados, _linDados;
        private List<string> _campos;

        // construtor
        public AlunoView() : base()
        {
            // base() chama o construtor Tela() da classe pai (poderia ser omitido)

            this._campos = new List<string>();
            this._campos.Add("Matrícula :");
            this._campos.Add("Nome      :");
            this._campos.Add("Email     :");
            this._campos.Add("Telefone  :");

            this._colIni = 22;
            this._linIni = 6;

            this._colFin = _colIni + this._campos[0].Length + 1 + 42;
            // +1 para colocar o traçado vertical direito depois dos 
            // +42 para ter espaço para o usuário digitar os dados

            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Titulo e um espaço para perguntas

            this._colDados = this._colIni + this._campos[0].Length + 2;
            this._linDados = this._linIni + 2;
        }

        public void MostrarFormulario()
        {

            this.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Alunos"
            );


            int linha = this._linDados;
            for (int i = 0; i < this._campos.Count; i++)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(this._campos[i]);
                linha++;
            }

            // ou podemos usar o comando foreach
            /*
            foreach (string campo in this._campos)
            {
                Console.SetCursorPosition(this._colIni+1, linha);
                Console.Write(campo);
                linha++;
            }
            */
        }


        public void EntrarDados(string qual, AlunoModel aluno)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (código)
                Console.SetCursorPosition(this._colDados, this._linDados);
                aluno.Matricula = Console.ReadLine();
            }
            else if (qual == "DT")
            {
                // limpa a área da tela antes de perguntar os dados
                // necessário no momento de alterações
                this.LimparArea(_colDados, _linDados + 1, _colFin - 1, _linDados + 3);

                // pergunta todos os outros dados
                Console.SetCursorPosition(this._colDados, this._linDados+1);
                aluno.Nome = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados+2);
                aluno.Email = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados+3);
                aluno.Telefone = Console.ReadLine();
            }
        }


        // Perguntar() foi movido para a classe Tela e é herdado aqui


        public void MostrarDados(AlunoModel aluno)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(aluno.Nome);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(aluno.Email);

            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(aluno.Telefone);
        }


    }
}
