using ProjetoFacul.BLL;
using ProjetoFacul.DAL;
using ProjetoFacul.Models;
using ProjetoFacul.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFacul.UI.Web
{
    public static class AppContainer
    {
        public static IClienteDados ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }

        public static IProdutoDados ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;
        }
        public static IPedidoDados ObterPedidoBLL()
        {
            var dal = new PedidoDAL();
            var bll = new PedidoBLL(dal);
            return bll;
        }
    }
}