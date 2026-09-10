using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Biblioteca.model
{
    internal class AlunoModel
    {
        // atributos
        private string _matricula;
        private string _nome;
        private string _email;
        private string _telefone;
 
        public AlunoModel(string matricula, string nome, string email, string telefone)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }
 
        public AlunoModel()
        {
            this.Matricula = "";
            this.Nome = "";
            this.Email = "";
            this.Telefone = "";
        }
 
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefone { get => _telefone; set => _telefone = value; }
 
 
 
    }
}
 
 
 
 