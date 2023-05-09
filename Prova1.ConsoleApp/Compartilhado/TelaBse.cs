using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public char MostrarTelaCrud()
        {
            char op;

            Console.WriteLine("Menu CRUD");
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Visualizar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Remover");
            Console.WriteLine("S - Sair");
            Console.WriteLine();
            Console.WriteLine("Opção: ");
            op = Convert.ToChar(Console.ReadLine());

            return op;
        }       
    }
}
