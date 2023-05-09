using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.ConsoleApp.Compartilhado
{
    internal abstract class EntidadeBase
    {
        public int id = 0;

        public abstract string MostrarEnt(EntidadeBase entidade);

        public abstract void Editar(EntidadeBase entAlterada, EntidadeBase entAntiga);
    
    }
}
