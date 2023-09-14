using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models
{
    public interface IClienteDados
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(string Id);
        List<Cliente> ObterTodos();
        Cliente ObterPorId(string id);
        Cliente ObterPorEmail(string email);

    }
}
