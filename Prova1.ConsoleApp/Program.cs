using Prova1.ConsoleApp.Compartilhado;
using Prova1.ConsoleApp.ModuloGarcom;
using Prova1.ConsoleApp.ModuloMesa;
using Prova1.ConsoleApp.ModuloProduto;

namespace Prova1.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                CriarOBJ();

                char op;
                do
                {
                    Console.WriteLine("Menu princial");
                    Console.WriteLine("1 - Garçom");
                    Console.WriteLine("2 - Cliente");
                    Console.WriteLine("3 - Conta");
                    Console.WriteLine("4 - Produto");
                    Console.WriteLine("S - Sair");
                    Console.Write("Opção: ");
                    op = Convert.ToChar(Console.ReadLine());

                    while (op != '1' || op != '2' || op != '3' || op != '4' || op != 's' || op != 'S')
                    {
                        Console.Write("Digite uma opção válida: ");
                        op = Convert.ToChar(Console.ReadLine());
                    }

                    if (op == '1' || op == '2' || op == '3' || op == '4')
                    {
                        Opcoes(op);
                    }

                } while (op != 's' && op != 'S');
            }

            static void Opcoes(char op)
            {
                TelaGarcom telaG = new TelaGarcom();
                TelaMesa telaM = new TelaMesa();
                TelaConta telaC = new TelaConta();
                TelaProduto telaP = new TelaProduto();

                switch (op)
                {
                    case '1':
                        telaG.MenuGarcom();
                        break;

                    case '2':
                        telaM.MenuMesa();
                        break;

                    case '3':
                        telaC.MenuTelaConta();
                        break;

                    case '4':
                        telaP.MenuProduto();
                        break;
                }
            }

            static void CriarOBJ()
            {
                RepositorioBase rep = new RepositorioBase();

                Mesa mesa = new Mesa(2, true, "lado de fora");
                Mesa mesa2 = new Mesa(1, false, "lado de dentro");
                rep.Inserir(mesa);
                rep.Inserir(mesa2);

                Garcom gar = new Garcom("joao", "123");
                Garcom gar2 = new Garcom("jose", "456");
                rep.Inserir(gar);
                rep.Inserir(gar2);

                Produto prod = new Produto("batata", "porção", 20);
                Produto prod2 = new Produto("frango", "porção", 30);
                rep.Inserir(prod);
                rep.Inserir(prod2);
        }   }        
    }
}