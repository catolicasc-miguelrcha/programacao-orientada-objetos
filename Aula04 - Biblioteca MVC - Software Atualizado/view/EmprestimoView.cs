using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class EmprestimoView
    {
        // atributos
        private int _colIni, _linIni, _colFin, _linFin, _colDados, _linDados;
        private List<string> _campos;
        private Tela _tela;

        // construtor
        public EmprestimoView()
        {
            this._tela = new Tela();

            this._campos = new List<string>();
            this._campos.Add("Número       :");
            this._campos.Add("ISBN         :");
            this._campos.Add("Matrícula    :");
            this._campos.Add("Data Empr.   :");
            this._campos.Add("Devol. Prev. :");
            this._campos.Add("Devol. Efet. :");
            this._campos.Add("Situação     :");

            this._colIni = 15;
            this._linIni = 5;

            this._colFin = _colIni + this._campos[0].Length + 1 + 42;
            // +1 para colocar o traçado vertical direito depois dos dados
            // +42 para ter espaço para o usuário digitar os dados

            this._linFin = _linIni + this._campos.Count + 1 + 2;
            // +1 para colocar o traçado horizontal na linha após o último campo
            // +2 para podermos usar um Titulo e um espaço para perguntas

            this._colDados = this._colIni + this._campos[0].Length + 2;
            this._linDados = this._linIni + 2;
        }

        public void MostrarFormulario()
        {

            this._tela.MontarMoldura(
                this._colIni, this._linIni,
                this._colFin, this._linFin,
                "Cadastro de Empréstimos"
            );


            int linha = this._linDados;
            for (int i = 0; i < this._campos.Count; i++)
            {
                Console.SetCursorPosition(this._colIni + 1, linha);
                Console.Write(this._campos[i]);
                linha++;
            }
        }


        public void EntrarDados(string qual, EmprestimoModel emprestimo)
        {
            if (qual == "PK")
            {
                // pergunta a chave primária (número do empréstimo)
                Console.SetCursorPosition(this._colDados, this._linDados);
                emprestimo.Numero = Convert.ToInt32(Console.ReadLine());
            }
            else if (qual == "DT")
            {
                // limpa a área da tela antes de perguntar os dados
                this._tela.LimparArea(_colDados, _linDados + 1, _colFin - 1, _linDados + 6);

                // pergunta apenas os dados que o usuário informa
                // (ISBN e Matrícula NÃO são consultados nas classes Livro e Aluno)
                Console.SetCursorPosition(this._colDados, this._linDados + 1);
                emprestimo.Isbn = Console.ReadLine();

                Console.SetCursorPosition(this._colDados, this._linDados + 2);
                emprestimo.Matricula = Console.ReadLine();

                // demais dados são preenchidos automaticamente
                emprestimo.DataEmprestimo = DateTime.Today;
                emprestimo.DataDevolucaoPrevista = DateTime.Today.AddDays(15);
                emprestimo.DataDevolucaoEfetiva = DateTime.MinValue;
                emprestimo.Situacao = "A";

                // mostra para o usuário o que foi preenchido automaticamente
                this.MostrarDatasESituacao(emprestimo);
            }
        }


        public string Perguntar(string pergunta)
        {
            string resposta = "";

            int coluna = this._colIni + 1;
            int linha = this._linFin - 1;
            string espacos = new string(' ', this._colFin - this._colIni - 1);

            // limpa a area da pergunta
            Console.SetCursorPosition(coluna, linha);
            Console.Write(espacos);

            // faz a pergunta ao usuário
            Console.SetCursorPosition(coluna, linha);
            Console.Write(pergunta);
            resposta = Console.ReadLine();

            return resposta;
        }


        public void MostrarDados(EmprestimoModel emprestimo)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 1);
            Console.Write(emprestimo.Isbn);

            Console.SetCursorPosition(this._colDados, this._linDados + 2);
            Console.Write(emprestimo.Matricula);

            this.MostrarDatasESituacao(emprestimo);
        }


        // mostra os campos de data e situação (usado no cadastro e na consulta)
        private void MostrarDatasESituacao(EmprestimoModel emprestimo)
        {
            Console.SetCursorPosition(this._colDados, this._linDados + 3);
            Console.Write(emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"));

            Console.SetCursorPosition(this._colDados, this._linDados + 4);
            Console.Write(emprestimo.DataDevolucaoPrevista.ToString("dd/MM/yyyy"));

            // a data efetiva só existe depois que o livro for devolvido
            if (emprestimo.Situacao == "E")
            {
                Console.SetCursorPosition(this._colDados, this._linDados + 5);
                Console.Write(emprestimo.DataDevolucaoEfetiva.ToString("dd/MM/yyyy"));
            }

            Console.SetCursorPosition(this._colDados, this._linDados + 6);
            if (emprestimo.Situacao == "A") Console.Write("A - Ativo");
            else Console.Write("E - Encerrado");
        }


    }
}
