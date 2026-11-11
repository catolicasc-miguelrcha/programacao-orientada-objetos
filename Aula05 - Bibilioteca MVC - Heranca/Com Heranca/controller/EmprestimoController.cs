using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class EmprestimoController
    {
        // atributos
        private List<EmprestimoModel> _colecaoEmprestimos;
        private int _posicao;

        // associações com as outras classes (para consultar livros e alunos)
        private LivroController _livroController;
        private AlunoController _alunoController;


        // construtor
        public EmprestimoController(LivroController livroController, AlunoController alunoController)
        {
            this._livroController = livroController;
            this._alunoController = alunoController;

            this._colecaoEmprestimos = new List<EmprestimoModel>();

            // adiciona 2 empréstimos na coleção para testarmos a consulta posteriormente
            // empréstimo 1: ATIVO
            this._colecaoEmprestimos.Add(
                new EmprestimoModel(1, "123", "123",
                    DateTime.Today, DateTime.Today.AddDays(15),
                    DateTime.MinValue, "A")
            );
            // empréstimo 2: ENCERRADO (já devolvido)
            this._colecaoEmprestimos.Add(
                new EmprestimoModel(2, "123", "123",
                    DateTime.Today.AddDays(-20), DateTime.Today.AddDays(-5),
                    DateTime.Today.AddDays(-7), "E")
            );
        }


        private bool Buscar(int numero)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoEmprestimos.Count; i++)
            {
                if (this._colecaoEmprestimos[i].Numero == numero)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }

            return encontrei;
        }


        // usado pelo LivroController para impedir a exclusão de um livro
        // que possua empréstimos (ativos ou encerrados)
        public bool ExisteEmprestimoDoLivro(string isbn)
        {
            bool existe = false;

            for (int i = 0; i < this._colecaoEmprestimos.Count; i++)
            {
                if (this._colecaoEmprestimos[i].Isbn == isbn)
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }


        // usado pelo AlunoController para impedir a exclusão de um aluno
        // que possua empréstimos (ativos ou encerrados)
        public bool ExisteEmprestimoDoAluno(string matricula)
        {
            bool existe = false;

            for (int i = 0; i < this._colecaoEmprestimos.Count; i++)
            {
                if (this._colecaoEmprestimos[i].Matricula == matricula)
                {
                    existe = true;
                    break;
                }
            }

            return existe;
        }


        public void ExecutarCRUD()
        {
            EmprestimoView view = new EmprestimoView();
            EmprestimoModel emprestimo = new EmprestimoModel();
            string resp;
            string titulo, nome;
            view.MostrarFormulario();

            // pergunta o código
            view.EntrarDados("PK", emprestimo);

            // busca pelo código
            bool achei = this.Buscar(emprestimo.Numero);

            // se o código NÃO FOI encontrado
            if (!achei)
            {
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("Número não encontrado! Deseja cadastrar (S/N) : ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta o ISBN e consulta o livro
                    view.EntrarDados("ISBN", emprestimo);
                    titulo = this._livroController.ConsultarTitulo(emprestimo.Isbn);

                    // se o livro NÃO FOI encontrado
                    if (titulo == null)
                    {
                        view.Perguntar("ISBN não encontrado! Cadastro cancelado. ENTER : ");
                    }
                    // se o livro FOI encontrado
                    else
                    {
                        // mostra o título do livro
                        view.MostrarTitulo(titulo);

                        // pergunta a matrícula e consulta o aluno
                        view.EntrarDados("MATRICULA", emprestimo);
                        nome = this._alunoController.ConsultarNome(emprestimo.Matricula);

                        // se o aluno NÃO FOI encontrado
                        if (nome == null)
                        {
                            view.Perguntar("Matrícula não encontrada! Cadastro cancelado. ENTER : ");
                        }
                        // se o aluno FOI encontrado
                        else
                        {
                            // mostra o nome do aluno
                            view.MostrarNome(nome);

                            // preenche demais dados
                            // (datas e situação são preenchidas automaticamente)
                            view.EntrarDados("DT", emprestimo);

                            // pergunta se confirma o cadastro
                            resp = view.Perguntar("Confirma cadastro (S/N) : ");

                            // se SIM
                            if (resp.ToLower() == "s")
                            {
                                // adiciona o novo registro
                                this._colecaoEmprestimos.Add(emprestimo);
                            }
                        }
                    }
                }
            }
            // se o codigo FOI encontrado
            else
            {
                // consulta o título do livro e o nome do aluno deste empréstimo
                titulo = this._livroController.ConsultarTitulo(this._colecaoEmprestimos[this._posicao].Isbn);
                nome = this._alunoController.ConsultarNome(this._colecaoEmprestimos[this._posicao].Matricula);

                // mostra os dados do registro encontrado
                view.MostrarDados(this._colecaoEmprestimos[this._posicao], titulo, nome);

                // se o empréstimo está ATIVO
                if (this._colecaoEmprestimos[this._posicao].Situacao == "A")
                {
                    // pergunta se deseja registrar a devolução
                    resp = view.Perguntar("Deseja registrar a devolução (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // registra a data da devolução (data do computador)
                        // e encerra o empréstimo
                        this._colecaoEmprestimos[this._posicao].DataDevolucaoEfetiva = DateTime.Today;
                        this._colecaoEmprestimos[this._posicao].Situacao = "E";

                        // mostra os dados atualizados
                        view.MostrarDados(this._colecaoEmprestimos[this._posicao], titulo, nome);
                        view.Perguntar("Devolução registrada! Tecle ENTER : ");
                    }
                }
                // se o empréstimo está ENCERRADO
                else
                {
                    // somente consulta: não permite alterar nem excluir,
                    // para preservar o histórico
                    view.Perguntar("Empréstimo encerrado! Tecle ENTER : ");
                }
            }
        }
    }
}
