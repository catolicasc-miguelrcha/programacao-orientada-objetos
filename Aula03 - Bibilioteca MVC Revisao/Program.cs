using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tela tela = new Tela(ConsoleColor.Magenta, ConsoleColor.Gray);
            tela.ConfigurarTela();

            List<string> opcoes = new List<string>();
            opcoes.Add("1 - Livros     ");
            opcoes.Add("2 - Alunos     ");
            opcoes.Add("3 - Empréstimos");
            opcoes.Add("4 - Relatórios ");
            opcoes.Add("0 - Sair       ");

            string opcao;

            while (true)
            {
                tela.MontarMoldura(0, 0, 79, 24, "Sistema de Biblioteca");
                opcao = tela.MostrarMenu(opcoes, 30, 10);

                if (opcao == "0") break;
                else if (opcao == "1") livroController.ExecutarCRUD();
                else if (opcao == "2") alunoController.ExecutarCRUD();
                //else if (opcao == "3") { }
                //else if (opcao == "4") { }
                else { tela.Centralizar("Opção inválida! Acione uma tecla para continuar...", 23, 0, 79); Console.ReadKey(); }
            }

            Console.Clear();
            Console.WriteLine("Adeus...");
        }
    }
}
