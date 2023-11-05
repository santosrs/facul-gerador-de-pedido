using ProjetoFacul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.BLL
{
    public class PedidoBLL : IPedidoDados
    {
        private IPedidoDados dal;

        public PedidoBLL(IPedidoDados pedidoDados)
        {
            this.dal = pedidoDados;
        }
        public void Incluir(Pedido pedido)
        {
            dal.Incluir(pedido);
        }

        public void Alterar(Pedido pedido)
        {
            dal.Alterar(pedido);
        }

        public void Excluir(int pedidoId)
        {
            dal.Excluir(pedidoId);
        }



        public Pedido ObterPorId(int id)
        {
            return dal.ObterPorId(id);
        }

        public List<Pedido> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
