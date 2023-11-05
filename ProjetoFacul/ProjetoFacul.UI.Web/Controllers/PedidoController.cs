using ProjetoFacul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoFacul.UI.Web.Models;

namespace ProjetoFacul.UI.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoDados bll;

        public PedidoController()
        {
            bll = AppContainer.ObterPedidoBLL();
        }


        public ActionResult Detalhes(int id)
        {
            var pedido = bll.ObterPorId(id);
            PedidoViewModel pedidoViewModel = ObterViewModel(pedido);

            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();

            pedidoViewModel.Clientes = bllCliente.ObterTodos();

            pedidoViewModel.Produtos = bllProduto.ObterTodos();
            pedidoViewModel.Produtos.Insert(0, new Produto() { Id = string.Empty, Nome = string.Empty });

            pedidoViewModel.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            return View(pedidoViewModel);
        }


        public ActionResult Alterar(int id)
        {
            var pedido = bll.ObterPorId(id);
            PedidoViewModel pedidoViewModel = ObterViewModel(pedido);

            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();

            pedidoViewModel.Clientes = bllCliente.ObterTodos();

            pedidoViewModel.Produtos = bllProduto.ObterTodos();
            pedidoViewModel.Produtos.Insert(0, new Produto() { Id = string.Empty, Nome = string.Empty });

            pedidoViewModel.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            return View(pedidoViewModel);

        }

        [HttpPost]
        public ActionResult Alterar(PedidoViewModel pedido)
        {
            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();


            pedido.Clientes = bllCliente.ObterTodos();

            pedido.Produtos = bllProduto.ObterTodos();
            pedido.Produtos.Insert(0, new Produto() { Id = string.Empty, Nome = string.Empty });

            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            if (Request.Form["incluirProduto"] == "Incluir")
            {
                ProcessarPedidoIncluir(pedido, bllProduto);
            }
            else if (Request.Form["excluirProduto"] == "Excluir")
            {
                ProcessarPedidoExcluir(pedido, bllProduto);
            }
            else if (Request.Form["Gravar"] == "Gravar")
            {

                var pedidoModel = ObterModel(pedido);
                bll.Alterar(pedidoModel);
                return RedirectToAction("Index");
            }


            return View(pedido);

        }

        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
        public ActionResult Incluir()
        {
            var bllCliente = AppContainer.ObterClienteBLL();
            var bllProduto = AppContainer.ObterProdutoBLL();


            var pedido = new PedidoViewModel();
            pedido.Clientes = bllCliente.ObterTodos();

            pedido.Produtos = bllProduto.ObterTodos();
            pedido.Produtos.Insert(0, new Produto() { Id = string.Empty, Nome = string.Empty });

            pedido.NovoItemProdutoId = string.Empty;
            pedido.NovoItemQuantidade = 0;

            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();
            return View(pedido);
        }


        [HttpPost]
        public ActionResult Incluir(PedidoViewModel pedido)
        {

            var bllProduto = AppContainer.ObterProdutoBLL();
            var bllCliente = AppContainer.ObterClienteBLL();


            pedido.Clientes = bllCliente.ObterTodos();

            pedido.Produtos = bllProduto.ObterTodos();
            pedido.Produtos.Insert(0, new Produto() { Id = string.Empty, Nome = string.Empty });

            pedido.FormasPagamento = Enum.GetNames(typeof(FormaPagamentoEnum)).ToList();

            if (Request.Form["incluirProduto"] == "Incluir")
            {
                ProcessarPedidoIncluir(pedido, bllProduto);
            }
            else if (Request.Form["excluirProduto"] == "Excluir")
            {
                ProcessarPedidoExcluir(pedido, bllProduto);
            }
            else if (Request.Form["Gravar"] == "Gravar")
            {

                var pedidoModel = ObterModel(pedido);
                bll.Incluir(pedidoModel);
                return RedirectToAction("Index");
            }


            return View(pedido);
        }
        private PedidoViewModel ObterViewModel(Pedido pedidoModel)
        {
            var pedidoViewModel = new PedidoViewModel();
            pedidoViewModel.Id = pedidoModel.Id;
            pedidoViewModel.Data = pedidoModel.Data;
            pedidoViewModel.ClienteId = pedidoModel.Cliente.Id;
            pedidoViewModel.ClienteNome = pedidoModel.Cliente.Nome;
            pedidoViewModel.FormaPagamento = pedidoModel.FormaPagamento;
            int ordem = 1;
            foreach (var item in pedidoModel.Items)
            {
                pedidoViewModel.Items.Add(new PedidoViewModel.Item()
                {
                    ProdutoId = item.Produto.Id,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    ProdutoNome = item.Produto.Nome
                });
                ordem++;
            }
            return pedidoViewModel;
        }


        private Pedido ObterModel(PedidoViewModel pedidoViewModel)
        {
            var pedidoModel = new Pedido();
            pedidoModel.Id = pedidoViewModel.Id;
            pedidoModel.Data = pedidoViewModel.Data;
            pedidoModel.Cliente = new Cliente() { Id = pedidoViewModel.ClienteId };
            pedidoModel.FormaPagamento = pedidoViewModel.FormaPagamento;
            int ordem = 1;
            foreach (var item in pedidoViewModel.Items)
            {
                pedidoModel.Items.Add(new Pedido.Item()
                {
                    Ordem = ordem,
                    Preco = item.Preco,
                    Produto = new Produto() { Id = item.ProdutoId },
                    Quantidade = item.Quantidade
                });
                ordem++;
            }
            return pedidoModel;
        }

        private void ProcessarPedidoExcluir(PedidoViewModel pedido, IProdutoDados bllProduto)
        {

            var produto = bllProduto.ObterPorId(pedido.ExcluirItemProdutoId);
            if (produto != null)
            {
                var item = pedido.Items.Where(m => m.ProdutoId == pedido.ExcluirItemProdutoId).FirstOrDefault();
                if (item != null)
                {
                    pedido.Items.Remove(item);
                }
            }
        }

        private static void ProcessarPedidoIncluir(PedidoViewModel pedido, IProdutoDados bllProduto)
        {
            var item = new PedidoViewModel.Item();
            item.ProdutoId = pedido.NovoItemProdutoId;
            item.Quantidade = pedido.NovoItemQuantidade;

            pedido.NovoItemProdutoId = string.Empty;
            pedido.NovoItemQuantidade = 0;

            var produto = bllProduto.ObterPorId(item.ProdutoId);
            if (produto != null)
            {

                item.Preco = produto.Preco;
                item.ProdutoNome = produto.Nome;
                item.ProdutoFornecedor = produto.Fornecedor;

                var itemExistente = pedido.Items.Where(m => m.ProdutoId == item.ProdutoId).FirstOrDefault();
                if (itemExistente == null)
                {
                    pedido.Items.Add(item);
                }
                else
                {
                    itemExistente.Quantidade += item.Quantidade;
                }
            }
        }

        public ActionResult Excluir(int Id)
        {
            var pedido = bll.ObterPorId(Id);
            return View(pedido);

        }
        [HttpPost]

        public ActionResult Excluir(int Id, FormCollection form)
        {
             try
             {
                    bll.Excluir(Id);
                    return RedirectToAction("Index");
             }
             catch (Exception ex)
             {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    var pedido = bll.ObterPorId(Id);
                    return View(pedido);

             }
        }
        


    }
}