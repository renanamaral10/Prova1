using Prova1.ConsoleApp.Compartilhado;
using Prova1.ConsoleApp.ModuloMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp
{
    internal class TelaMesa : TelaBase
    {
        public void MenuMesa()
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
                    InserirMesa();
                    break;

                case '2':
                    VisualizarMesa();
                    break;

                case '3':
                    EditarMesa();
                    break;

                case '4':
                    RemoverMesa();
                    break;
            }
        }

        public void RemoverMesa()
        {
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID da mesa que será Removida: ");
            id = Convert.ToInt32(Console.ReadLine());

            rep.Remover(id);
        }

        public void EditarMesa()
        {
            RepositorioBase rep = new RepositorioBase();
            int numMesa, id;
            bool ocupado;
            char ocupadoSN;
            string localizacao;

            Console.Write("Digite o ID da Mesa que será Alterado: ");
            id = Convert.ToInt32(Console.ReadLine());

            EntidadeBase entAlterar = rep.VerificadorID(id);

            if (entAlterar != null)
            {

                Console.Write("Digite o numero da mesa: ");
                numMesa = Convert.ToInt32(Console.ReadLine());

                Console.Write("A mesa está ocupada? (S/N): ");
                ocupadoSN = Convert.ToChar(Console.ReadLine());

                while (ocupadoSN != 's' || ocupadoSN != 'S' || ocupadoSN != 'n' || ocupadoSN != 'N')
                {
                    Console.WriteLine("Opção inválida");
                    Console.Write("A mesa está ocupada? (S/N): ");
                    ocupadoSN = Convert.ToChar(Console.ReadLine());
                }

                if (ocupadoSN == 's' || ocupadoSN == 'S')
                {
                    ocupado = true;
                }
                else
                {
                    ocupado = false;
                }

                Console.Write("Digite a localização da mesa: ");
                localizacao = Console.ReadLine();

                Mesa mesa = new Mesa(numMesa, ocupado, localizacao);

                rep.Editar(mesa, entAlterar);
            }
            else
            {
                Console.WriteLine("Entidade não encontrada!");
            }
        }

        public void VisualizarMesa()
        {
            Mesa mesa = null;
            string mostrar;
            int id;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o ID da mesa desejada: ");
            id = Convert.ToInt32(Console.ReadLine());

            mostrar = rep.ProcuradorEntidade(mesa, id);

            Console.WriteLine(mostrar);
        }

        public void InserirMesa()
        {
            int numMesa;
            bool ocupado;
            char ocupadoSN;
            string localizacao;
            RepositorioBase rep = new RepositorioBase();

            Console.Write("Digite o numero da mesa: ");
            numMesa = Convert.ToInt32(Console.ReadLine());

            Console.Write("A mesa está ocupada? (S/N): ");
            ocupadoSN = Convert.ToChar(Console.ReadLine());

            while (ocupadoSN != 's' || ocupadoSN != 'S' || ocupadoSN != 'n' || ocupadoSN != 'N')
            {
                Console.WriteLine("Opção inválida");
                Console.Write("A mesa está ocupada? (S/N): ");
                ocupadoSN = Convert.ToChar(Console.ReadLine());
            }

            if (ocupadoSN == 's' || ocupadoSN == 'S')
            {
                ocupado = true;
            }
            else
            {
                ocupado = false;
            }

            Console.Write("Digite a localização da mesa: ");
            localizacao = Console.ReadLine();

            Mesa mesa = new Mesa(numMesa, ocupado, localizacao);
            rep.Inserir(mesa);
        }       
    }
}
