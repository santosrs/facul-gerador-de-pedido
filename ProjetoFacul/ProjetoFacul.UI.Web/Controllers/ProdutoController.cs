using ProjetoFacul.BLL;
using ProjetoFacul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFacul.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoDados bll;

        //
        // Construtor
        //
        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }

        public ActionResult Excluir(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        //
        // Excluir (post)
        //
        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(id);
                return View(produto);
            }

        }

        //
        // Alterar
        //
        public ActionResult Alterar(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        //
        // Alterar (post)
        //
        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {

                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }



        //
        // Detalhes
        //
        public ActionResult Detalhes(string id)
        {
            var produto = bll.ObterPorId(id);
            return View(produto);
        }

        // GET: Produto
        public ActionResult Incluir()
        {
            var pro = new Produto();
            return View();
        }
        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {

                bll.Incluir(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }
        public ActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}