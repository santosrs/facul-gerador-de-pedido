using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models.Interfaces
{
    public interface IPedidoDados:IDados<Pedido>
    {
        void Excluir(int pedidoId);
        Pedido ObterPorId(int id);
        List<Pedido> ObterTodos();
    }
}
