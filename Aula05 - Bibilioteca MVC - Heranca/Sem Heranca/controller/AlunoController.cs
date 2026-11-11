using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class AlunoController
    {
        // atributos
        private List<AlunoModel> _colecaoAlunos;
        private int _posicao;
        // associação com a classe Emprestimo (para verificar antes de excluir)
        private EmprestimoController _emprestimoController;


        // construtor
        public AlunoController()
        {
            this._colecaoAlunos = new List<AlunoModel>();
            // adiciona 1 aluno na coleção para testarmos a consulta posteriormente
            this._colecaoAlunos.Add(
                new AlunoModel("123","Zé Colmeia","zecolmeia@gmail.com","99967-8976")
            );
        }


        // recebe o controller de empréstimos depois que ele for criado
        // (não é possível passar pelo construtor, pois o EmprestimoController
        // também precisa do AlunoController para ser criado)
        public void AssociarEmprestimos(EmprestimoController emprestimoController)
        {
            this._emprestimoController = emprestimoController;
        }


        private bool Buscar(string matricula)
        {
            bool encontrei = false;

            for (int i = 0; i < this._colecaoAlunos.Count; i++)
            {
                if (this._colecaoAlunos[i].Matricula == matricula)
                {
                    this._posicao = i;
                    encontrei = true;
                    break;
                }
            }

            return encontrei;
        }


        // usado pelo EmprestimoController para consultar um aluno
        // retorna o nome do aluno ou null se a matrícula não foi encontrada
        public string ConsultarNome(string matricula)
        {
            string nome = null;

            if (this.Buscar(matricula))
            {
                nome = this._colecaoAlunos[this._posicao].Nome;
            }

            return nome;
        }


        public void ExecutarCRUD()
        {
            AlunoView view = new AlunoView();
            AlunoModel aluno = new AlunoModel();
            string resp;
            view.MostrarFormulario();

            // pergunta o código
            view.EntrarDados("PK", aluno);

            // busca pelo código
            bool achei = this.Buscar(aluno.Matricula);

            // se o código NÃO FOI encontrado
            if (!achei)
            {
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("Matrícula não encontrada! Deseja cadastrar (S/N) : ");

                // se SIM
                if (resp.ToLower() == "s")
                {
                    // pergunta demais dados
                    view.EntrarDados("DT", aluno);

                    // pergunta se confirma o cadastro
                    resp = view.Perguntar("Confirma cadastro (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // adiciona o novo registro
                        this._colecaoAlunos.Add(aluno);
                    }
                }
            }
            // se o codigo FOI encontrado
            else
            {
                // mostra os dados do registro encontrado
                view.MostrarDados(this._colecaoAlunos[this._posicao]);

                // pergunta se deseja alterar/excluir/voltar
                resp = view.Perguntar("Deseja alterar/excluir/voltar (A/E/V) : ");

                // se deseja ALTERAR
                if (resp.ToLower() == "a")
                {
                    // pergunta os novos dados
                    view.EntrarDados("DT", aluno);

                    // pergunta se confirma alteração
                    resp = view.Perguntar("Confirma alteração (S/N) : ");

                    // se SIM
                    if (resp.ToLower() == "s")
                    {
                        // atualiza dos dados do registro
                        this._colecaoAlunos[this._posicao] = aluno;

                        // ou...
                        // this._colecaoAlunos[this._posicao].Nome = aluno.Nome;
                        // this._colecaoAlunos[this._posicao].Email = aluno.Email;
                        // this._colecaoAlunos[this._posicao].Telefone = aluno.Telefone;
                    }
                }

                // se deseja EXCLUIR
                if (resp.ToLower() == "e")
                {
                    // se o aluno possui empréstimos registrados
                    if (this._emprestimoController.ExisteEmprestimoDoAluno(aluno.Matricula))
                    {
                        // não permite a exclusão
                        view.Perguntar("Aluno com empréstimos! Exclusão negada. ENTER : ");
                    }
                    // se o aluno NÃO possui empréstimos
                    else
                    {
                        // pergunta se confirma exclusão
                        resp = view.Perguntar("Confirma exclusão (S/N) : ");

                        // se SIM
                        if (resp.ToLower() == "s")
                        {
                            // exclui o registro
                            this._colecaoAlunos.RemoveAt(this._posicao);
                        }
                    }
                }
            }
        }
    }
}
