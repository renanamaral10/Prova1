using Prova1.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.ModuloMesa
{
    internal class Mesa : EntidadeBase
    {
        public int numMesa;
        public bool ocupado;
        public string localizacao;

        public Mesa(int numMesa, bool ocupado, string localizacao)
        {
            base.id++;
            this.numMesa = numMesa;
            this.ocupado = ocupado;
            this.localizacao = localizacao;
        }

        public override string MostrarEnt(EntidadeBase ent)
        {
            Mesa mesa = (Mesa)ent;
            return $"Numero da Mesa: {mesa.numMesa}\nEsta Ocupada: {mesa.ocupado}\nLocalização: {mesa.localizacao}";
        }

        public override void Editar(EntidadeBase entAlterada, EntidadeBase entAntiga)
        {
            Mesa mesaAntigo = (Mesa)entAntiga;
            Mesa mesaAlterado = (Mesa)entAlterada;

            mesaAntigo.numMesa = mesaAlterado.numMesa;
            mesaAntigo.ocupado = mesaAlterado.ocupado;
            mesaAntigo.localizacao = mesaAlterado.localizacao;
        }       
    }
}
