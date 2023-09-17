using ProjetoFacul.BLL;
using ProjetoFacul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFacul.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            bll = new ClienteBLL();
        }


        public ActionResult Detalhes(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }
        public ActionResult Alterar(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

        //
        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {

                bll.Alterar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }

        public ActionResult Excluir(string id)
        {
            var cliente = bll.ObterPorId(id);
            return View(cliente);
        }

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
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        }



        public ActionResult Incluir()
        {
            var cli = new Cliente();
            return View();
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {
                
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
        }
        // GET: Cliente
        public ActionResult Index()
        {
            
            var lista = bll.ObterTodos();
            return View(lista);
        }
    }
}