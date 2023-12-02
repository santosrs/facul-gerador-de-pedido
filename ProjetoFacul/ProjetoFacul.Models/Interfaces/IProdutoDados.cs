using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models.Interfaces
{
    public interface IProdutoDados:IDados<Produto>
    {
        void Excluir(string id);
        Produto ObterPorId(string id);
        IEnumerable<Produto> ObterTodos();
    }
}
