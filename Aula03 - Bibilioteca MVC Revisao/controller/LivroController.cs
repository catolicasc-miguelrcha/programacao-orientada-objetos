using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Biblioteca.controller
{
    internal class LivroController
    {
        // atributos
        private List<LivroModel> _colecaoLivros;
 
        private LivroModel _livro;
        private LivroView _livroView;
 
        private int _posicao;
 
        // construtor
        public LivroController()
        {
            this._livroView = new LivroView();
            this._livro = new LivroModel();
 
            this._colecaoLivros = new List<LivroModel>();
            this._colecaoLivros.Add(
                new LivroModel(
                    "123", 
                    "Faca", 
                    "Jo Nesbo", 
                    "Policial", 
                    450)
                );
        }
 
        public void ExecutarCRUD()
        {
            this._livroView.MostrarFormulario();
            this._livro = this._livroView.EntrarDados("PK");
 
            Console.ReadKey();
        }
 
    }
}
