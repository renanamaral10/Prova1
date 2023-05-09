using Prova1.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.ModuloGarcom
{
    internal class TelaGarcom : TelaBase
    {
        public void MenuGarcom()
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
                    InserirGarcom();
                    break;

                case '2':
                    VisualizarGarcom();
                    break;

                case '3':
                    EditarGarcom();
                    break;

                case '4':
                    RemoverGarcom();
                    break;
            }
        }

        public void RemoverGarcom()
        {
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID do garçom que será Removido: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);
        }

        public void EditarGarcom()
        {
            Garcom garc;
            string nome, cpf;
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID do garçom que será Alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            EntidadeBase entAlterar = rep.VerificadorID(id);

            if (entAlterar != null)
            {
                Console.Write("Digite o nome do Garçom: ");
                nome = Console.ReadLine();

                Console.Write("Digite o CPF do Garçom: ");
                cpf = Console.ReadLine();

                garc = new Garcom(nome, cpf);

                rep.Editar(garc, entAlterar);
            }
            else
            {
                Console.WriteLine("Entidade não encontrada!");
            }
        }

        public void VisualizarGarcom()
        {
            Garcom garc = null;
            string mostrar;
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID do garçom desejado: ");
            id = Convert.ToInt32(Console.ReadLine());

            mostrar = rep.ProcuradorEntidade(garc, id);

            Console.WriteLine(mostrar);

        }

        public void InserirGarcom()
        {
            RepositorioBase rep = new RepositorioBase();
            string nome, cpf;

            Console.Write("Digite o nome do Garçom: ");
            nome = Console.ReadLine();

            Console.Write("Digite o CPF do Garçom: ");
            cpf = Console.ReadLine();

            Garcom garc = new Garcom(nome, cpf);
            rep.Inserir(garc);
        }       
    }
}
