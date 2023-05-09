using Prova1.ConsoleApp.Compartilhado;
using Prova1.ConsoleApp.ModuloConta;
using Prova1.ConsoleApp.ModuloGarcom;
using Prova1.ConsoleApp.ModuloMesa;
using Prova1.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp
{
    internal class TelaConta
    {
        public void MenuTelaConta()
        {
            char op;
            do
            {
                Console.WriteLine("Menu Tela Conta");
                Console.WriteLine("1 - Abrir Conta");
                Console.WriteLine("2 - Registrar Pedido");
                Console.WriteLine("3 - Fechar Conta");
                Console.WriteLine("4 - Visualizar Contas Abertas");
                Console.WriteLine("5 - Visualizar Total Faturado no Dia");
                Console.WriteLine("S - Sair");
                Console.Write("Opção: ");
                op = Convert.ToChar(Console.ReadLine());

                while (op != '1' || op != '2' || op != '3' || op != '4' || op != '5' || op != 's' || op != 'S')
                {
                    Console.Write("Digite uma opção válida: ");
                    op = Convert.ToChar(Console.ReadLine());
                }

                if (op == '1' || op == '2' || op == '3' || op == '4' || op == '5')
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
                    AbrirConta();
                    break;

                case '2':
                    RegistrarPedido();
                    break;

                case '3':
                    FecharConta();
                    break;

                case '4':
                    ViualizarContaAberta();
                    break;

                case '5':
                    TotalFaturadoDia();
                    break;
            }
        }

        public void AbrirConta()
        {
            Conta cont = null;

            if (cont.listaPedidos.Count != 0)
            {
                Pedido ped;
                Garcom garc;
                Mesa mesa;
                int idGarc, idMesa, idPed;
                RepositorioBase rep = new RepositorioBase();
                char op;

                do
                {
                    Console.Write("Digite o ID do Pedido: ");
                    idPed = Convert.ToInt32(Console.ReadLine());
                    ped = (Pedido)rep.VerificadorID(idPed);
                    Console.WriteLine();
                    Console.Write("Deseja adicionar mais um pedido? (S/N): ");
                    op = Convert.ToChar(Console.ReadLine());

                } while (op != 'n' && op != 'N');

                Console.Write("Digite o ID da Mesa: ");
                idMesa = Convert.ToInt32(Console.ReadLine());
                mesa = (Mesa)rep.VerificadorID(idMesa);

                Console.Write("Digite o ID do Garçom: ");
                idGarc = Convert.ToInt32(Console.ReadLine());
                garc = (Garcom)rep.VerificadorID(idGarc);

                Conta conta = new Conta(ped, garc, mesa);
                rep.InserirConta(conta);
            }
            else
            {
                Console.WriteLine("Não há pedidos!");
            }
        }

        public void RegistrarPedido()
        {
            RepositorioBase rep = new RepositorioBase();
            string tipoQuant;
            int quant, idProd;
            Produto prod;

            Console.Write("Digite o ID do Produto: ");
            idProd = Convert.ToInt32(Console.ReadLine());
            prod = (Produto)rep.VerificadorID(idProd);

            Console.Write("Digite o Tipo da Quantidade, ex(Porção, Litro, etc...): ");
            tipoQuant = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            quant = Convert.ToInt32(Console.ReadLine());

            Pedido pedido = new Pedido(quant, prod, tipoQuant);

            rep.Inserir(pedido);
        }

        public void FecharConta()
        {
            RepositorioBase rep = new RepositorioBase();
            int id;
            bool verificador = false;
            Console.Write("Digite o ID da Conta: ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (Conta cont in rep.SelecTodasContas())
            {
                if (cont.id == id)
                {
                    verificador = true;
                    cont.contaAberta = false;
                    break;
                }
            }

            if (verificador == false)
            {
                Console.WriteLine("Conta não Encontrada!");
            }
        }

        public void ViualizarContaAberta()
        {
            RepositorioBase rep = new RepositorioBase();

            Console.WriteLine("Dados da Conta");
            foreach (Conta cont in rep.SelecTodasContas())
            {
                if (cont.contaAberta == true)
                {
                    Console.WriteLine($"\tID: {cont.id}\n\tMesa: {cont.mesa.numMesa}");
                }
            }
        }

        public void TotalFaturadoDia()
        {
            Conta conta = null;
            decimal somaTotal = conta.PegarValorPedidos();

            Console.WriteLine("Total faturado no dia: " + somaTotal);
        }       
    }
}
