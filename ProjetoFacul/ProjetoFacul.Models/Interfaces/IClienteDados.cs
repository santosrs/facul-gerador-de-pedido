using ProjetoFacul.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models
{
    public interface IClienteDados:IDados<Cliente>
    {
        Cliente ObterPorEmail(string email);
        void Excluir(string id);
        Cliente ObterPorId(string id);
        IEnumerable<Cliente> ObterTodos();

    }
}
