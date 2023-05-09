using Prova1.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.ModuloGarcom
{
    internal class Garcom : EntidadeBase
    {
        public string nome;
        public string cpf;

        public Garcom(string nome, string cpf)
        {
            base.id++;
            this.nome = nome;
            this.cpf = cpf;
        }

        public override string MostrarEnt(EntidadeBase ent)
        {
            Garcom garc = (Garcom)ent;
            return $"Nome: {garc.nome}\nCPF: {garc.cpf}";
        }

        public override void Editar(EntidadeBase entAlterada, EntidadeBase entAntiga)
        {
            Garcom garcAntigo = (Garcom)entAntiga;
            Garcom garcAlterado = (Garcom)entAlterada;

            garcAntigo.nome = garcAlterado.nome;
            garcAntigo.cpf = garcAlterado.cpf;
        }       
    }
}
