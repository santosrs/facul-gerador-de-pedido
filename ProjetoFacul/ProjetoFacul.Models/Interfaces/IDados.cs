using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models.Interfaces
{
    public interface IDados<T>
    {
        void Incluir(T entidade);
        void Alterar(T entidade);       
        IEnumerable<string> Validar();
        
    }
}
