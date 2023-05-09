using Prova1.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.ModuloProduto
{
    internal class Produto : EntidadeBase
    {
        public string nome;
        public string tipoDeQuant;
        public decimal valor;

        public Produto(string nome, string tipoDeQuant, decimal valor)
        {
            base.id++;
            this.nome = nome;
            this.tipoDeQuant = tipoDeQuant;
            this.valor = valor;
        }

        public override string MostrarEnt(EntidadeBase ent)
        {
            Produto prod = (Produto)ent;
            return $"Nome: {prod.nome}\nTipo: {prod.tipoDeQuant}\nValor: {prod.valor}";
        }

        public override void Editar(EntidadeBase entAlterada, EntidadeBase entAntiga)
        {
            Produto prodAntigo = (Produto)entAntiga;
            Produto prodAlterado = (Produto)entAlterada;

            prodAntigo.nome = prodAlterado.nome;
            prodAntigo.tipoDeQuant = prodAlterado.tipoDeQuant;
            prodAntigo.valor = prodAlterado.valor;
        }       
    }
}
