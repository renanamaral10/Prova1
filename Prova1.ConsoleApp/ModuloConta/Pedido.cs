using Prova1.ConsoleApp.Compartilhado;
using Prova1.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp
{
    internal class Pedido : EntidadeBase
    {
        public string tipoQuant;
        public int quant;
        public Produto prod;
        public decimal valorPedido;

        public Pedido(int quant, Produto prod, string tipoQuant)
        {
            this.quant = quant;
            this.prod = prod;
            calcValorPedido();
            this.tipoQuant = tipoQuant;

        }

        public void calcValorPedido()
        {
            this.valorPedido = prod.valor * quant;
        }

        public override void Editar(EntidadeBase entAlterada, EntidadeBase entAntiga) { }

        public override string MostrarEnt(EntidadeBase entidade)
        {
            Pedido ped = (Pedido)entidade;
            return $"Produto: \n\t{ped.quant} {ped.tipoQuant} de {ped.prod.nome} - Valor: {ped.valorPedido}";
        }       
    }
}
