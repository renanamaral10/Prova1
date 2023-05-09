using Prova1.ConsoleApp.ModuloConta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.Compartilhado
{
    internal class RepositorioBase
    {
        private ArrayList listaRegistros = new ArrayList();
        private ArrayList listaConta = new ArrayList();

        public void InserirConta(Conta conta)
        {
            listaConta.Add(conta);
        }

        public ArrayList SelecTodasContas()
        {
            return listaConta;
        }

        public void Inserir(EntidadeBase entidade)
        {
            listaRegistros.Add(entidade);
        }

        public void Remover(int id)
        {
            foreach (EntidadeBase entidade in listaRegistros)
            {
                if (entidade.id == id)
                {
                    listaRegistros.Remove(entidade);
                }
            }

        }
        public string ProcuradorEntidade(EntidadeBase ent, int id)
        {
            EntidadeBase entidade = VerificadorID(id);

            return ent.MostrarEnt(entidade);

        }

        public void Editar(EntidadeBase entidadeAlterada, EntidadeBase entidadeAntiga)
        {
            entidadeAntiga.Editar(entidadeAlterada, entidadeAntiga);
        }

        public EntidadeBase VerificadorID(int id)
        {
            foreach (EntidadeBase entidade in listaRegistros)
            {
                if (entidade.id == id)
                {
                    return entidade;
                }
            }
            return null;
        }       
    }
}
