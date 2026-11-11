using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class EmprestimoModel
    {
        // atributos
        private int _numero;
        private string _isbn;
        private string _matricula;
        private DateTime _dataEmprestimo;
        private DateTime _dataDevolucaoPrevista;
        private DateTime _dataDevolucaoEfetiva;
        private string _situacao;   // "A" = Ativo, "E" = Encerrado

        // propriedades
        public int Numero { get => _numero; set => _numero = value; }
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public DateTime DataEmprestimo { get => _dataEmprestimo; set => _dataEmprestimo = value; }
        public DateTime DataDevolucaoPrevista { get => _dataDevolucaoPrevista; set => _dataDevolucaoPrevista = value; }
        public DateTime DataDevolucaoEfetiva { get => _dataDevolucaoEfetiva; set => _dataDevolucaoEfetiva = value; }
        public string Situacao { get => _situacao; set => _situacao = value; }


        // construtores
        public EmprestimoModel(int numero, string isbn, string matricula,
            DateTime dataEmprestimo, DateTime dataDevolucaoPrevista,
            DateTime dataDevolucaoEfetiva, string situacao)
        {
            this.Numero = numero;
            this.Isbn = isbn;
            this.Matricula = matricula;
            this.DataEmprestimo = dataEmprestimo;
            this.DataDevolucaoPrevista = dataDevolucaoPrevista;
            this.DataDevolucaoEfetiva = dataDevolucaoEfetiva;
            this.Situacao = situacao;
        }

        public EmprestimoModel()
        {
            this.Numero = 0;
            this.Isbn = "";
            this.Matricula = "";
            this.DataEmprestimo = DateTime.MinValue;
            this.DataDevolucaoPrevista = DateTime.MinValue;
            // MinValue indica "ainda não devolvido"
            this.DataDevolucaoEfetiva = DateTime.MinValue;
            this.Situacao = "";
        }

    }
}
