using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Biblioteca.controller
{
    internal class AlunoController
    {
        // atributos
        private List<AlunoModel> _colecaoAlunos;
 
        private AlunoModel _aluno;
        private AlunoView _alunoView;
 
        private int _posicao;
 
        // construtor
        public AlunoController()
        {
            this._alunoView = new AlunoView();
            this._aluno = new AlunoModel();
 
            this._colecaoAlunos = new List<AlunoModel>();
            this._colecaoAlunos.Add(
                new AlunoModel(
                    "1333183", 
                    "Miguel Rocha Xavier", 
                    "miguel.xavier@catolicasc.edu.br", 
                    "123456789"
                    )
                );
        }
 
        public void ExecutarCRUD()
        {
            this._alunoView.MostrarFormulario();
            this._aluno = this._alunoView.EntrarDados("PK");
 
            Console.ReadKey();
        }
 
    }
}
