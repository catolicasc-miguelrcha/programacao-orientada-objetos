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

        private AlunoModel _aluno;
        private AlunoView _alunoView;

        private int _posicao;

        // construtor
        public AlunoController()
        {

            this._colecaoAlunos = new List<AlunoModel>();
            // adiciona 1 aluno na coleção para testarmos a consulta posteriormente
            this._colecaoAlunos.Add(
                new AlunoModel("123","Zé Colmeia","zecolmeia@gmail.com","99967-8976")
            );
        }

        public void ExecutarCRUD()
        {

            AlunoModel aluno = new AlunoModel();
            AlunoView view = new AlunoView();
            string resp;


            view.MostrarFormulario();

            // pergunta o código
            view.EntrarDados("PK", aluno);

            // busca pelo código
            bool achei = this.BuscarAluno(aluno.Matricula);
            


            // se o código NÃO FOI encontrado
            if (!achei)
            {
                
            }
                // informa que NÃO EXISTE e pergunta se deseja cadastrar
                resp = view.Perguntar("Matricula não existe. Deseja cadastrar? (S/N) : ");
                // se SIM
                if (resp.ToLower() == "s") 
                {
                    // pergunta demais dados
                    view.EntrarDados("DT", aluno);
                    // pergunta se confirma o cadastro
                    resp = view.Perguntar("Confirma o cadastro? (S/N) : ");
                    // se SIM
                    if (resp.ToLower() == "s") 
                    {
                       // adiciona o novo registro
                        this._colecaoAlunos.Add(aluno); 
                    }
                        
                }
            // se o codigo FOI encontrado
            if (achei)
            {
                
            }

            else
            {
                view.Pergutar("Aluno já existe");
                Console.ReadKey();
              // mostra os dados do registro encontrado
                // pergunta se deseja alterar/excluir/voltar
                // se deseja ALTERAR
                    // pergunta os novos dados
                    // pergunta se confirma alteração
                    // se SIM
                        // atualiza dos dados do registro
                // se deseja EXCLUIR
                    // pergunta se confirma exclusão
                    // se SIM
                        // exclui o registro   
            }
        }




        private bool BuscarAluno(string matricula)
        {

            bool encontrei = false;
            
            // percorre a coleção de alunos
            for (int i = 0; i < this._colecaoAlunos.Count; i++)
            {
                // se o código do aluno na posição i for igual ao código informado
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

            // se não encontrar o código informado
            return false;

        }

    }
}
