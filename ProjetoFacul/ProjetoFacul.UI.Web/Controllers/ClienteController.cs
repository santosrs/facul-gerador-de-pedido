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
                var bll = new ClienteBLL();
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
            return View();
        }
    }
}