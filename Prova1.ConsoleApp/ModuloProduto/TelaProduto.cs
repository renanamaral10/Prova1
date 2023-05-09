using Prova1.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.ModuloProduto
{
    internal class TelaProduto : TelaBase
    {
        public void MenuProduto()
        {
            char op;
            do
            {
                op = this.MostrarTelaCrud();

                while (op != '1' || op != '2' || op != '3' || op != '4' || op != 's' || op != 'S')
                {
                    Console.Write("Digite uma opção válida: ");
                    op = Convert.ToChar(Console.ReadLine());
                }

                if (op != '1' || op != '2')
                {
                    Opcoes(op);
                }

            } while (op != 's' && op != 'S');
        }

        public void Opcoes(char op)
        {
            switch (op)
            {
                case '1':
                    InserirProduto();
                    break;

                case '2':
                    VisualizarProduto();
                    break;

                case '3':
                    EditarProduto();
                    break;

                case '4':
                    RemoverProduto();
                    break;
            }
        }

        public void RemoverProduto()
        {
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID do Produto que será Removido: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);
        }

        public void EditarProduto()
        {
            RepositorioBase rep = new RepositorioBase();
            string nome, tipoDeQuant;
            decimal valor;
            int id;

            Console.Write("Digite o ID do Produto que será Alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            EntidadeBase entAlterar = rep.VerificadorID(id);

            if (entAlterar != null)
            {
                Console.Write("Digite o nome do Produto: ");
                nome = Console.ReadLine();

                Console.Write("Digite o tipo da quantidade (Porção, litro, etc...): ");
                tipoDeQuant = Console.ReadLine();

                Console.Write("Digite o valor do Produto: ");
                valor = Convert.ToDecimal(Console.ReadLine());

                Produto prod = new Produto(nome, tipoDeQuant, valor);

                rep.Editar(prod, entAlterar);
            }
            else
            {
                Console.WriteLine("Entidade não encontrada!");
            }
        }

        public void VisualizarProduto()
        {
            Produto prod = null;
            string mostrar;
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID do produto desejado: ");
            id = Convert.ToInt32(Console.ReadLine());

            mostrar = rep.ProcuradorEntidade(prod, id);

            Console.WriteLine(mostrar);
        }

        public void InserirProduto()
        {
            RepositorioBase rep = new RepositorioBase();
            string nome, tipoDeQuant;
            decimal valor;

            Console.Write("Digite o nome do Produto: ");
            nome = Console.ReadLine();

            Console.Write("Digite o tipo da quantidade (Porção, litro, etc...): ");
            tipoDeQuant = Console.ReadLine();

            Console.Write("Digite o valor do Produto: ");
            valor = Convert.ToDecimal(Console.ReadLine());

            Produto prod = new Produto(nome, tipoDeQuant, valor);
            rep.Inserir(prod);
        }       
    }
}
