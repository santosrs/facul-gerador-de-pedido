using ProjetoFacul.Models;
using ProjetoFacul.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoFacul.UI.Web.Controllers
{
    
        public class ClienteController : Controller
        {


            private IClienteDados bll;

            public ClienteController()
            {
                bll = AppContainer.ObterClienteBLL();
            }

        [Authorize]
            public ActionResult Detalhes(string id)
            {
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        [Authorize]
        public ActionResult Index()
            {
                var lista = bll.ObterTodos();
                return View(lista);
            }
        [Authorize]
        public ActionResult Alterar(string id)
            {
                var cliente = bll.ObterPorId(id);
                var clienteViewModel = new ClienteViewModel()
            {

                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Tipo = cliente.Tipo,
                    Telefone = cliente.Telefone,
                    Celular = cliente.Celular,
                    Email = cliente.Email,
                    Endereco = cliente.Endereco,
                    Numero = cliente.Numero,
                    Complemento = cliente.Complemento,
                    Cep = cliente.Cep,
                    Cidade = cliente.Cidade,
                    UF = cliente.UF
        };
          if (cliente is Empresa)
            {
                clienteViewModel.CNPJ = ((Empresa)cliente).CNPJ;
            }

            else
            {
                clienteViewModel.CPF = ((Pessoa)cliente).CPF;
                clienteViewModel.RG = ((Pessoa)cliente).RG;
                clienteViewModel.DataNascimento = ((Pessoa)cliente).DataNascimento;

            }


            return View(clienteViewModel);
        }

            //
            [HttpPost]
            public ActionResult Alterar(ClienteViewModel clienteViewModel)
            {
                if (string.IsNullOrEmpty(clienteViewModel.Nome))
                {
                    ModelState.AddModelError("Nome", "O nome deve ser informado");
                }
                if (ModelState.IsValid)
                {
                    Cliente cliente;
                    if (clienteViewModel.Tipo == PessoaFisicaJuridica.PessoaFisica)
                    {
                        cliente = new Pessoa();
                        ((Pessoa)cliente).RG = clienteViewModel.RG;
                        ((Pessoa)cliente).CPF = clienteViewModel.CPF;
                        ((Pessoa)cliente).DataNascimento = clienteViewModel.DataNascimento;
                        cliente.Tipo = PessoaFisicaJuridica.PessoaFisica;

                    }
                    else
                    {
                        cliente = new Empresa();
                        ((Empresa)cliente).CNPJ = clienteViewModel.CNPJ;
                        cliente.Tipo = PessoaFisicaJuridica.PessoaJuridica;
                    }
                    cliente.Id = clienteViewModel.Id;
                    cliente.Nome = clienteViewModel.Nome;
                    cliente.Telefone = clienteViewModel.Telefone;
                    cliente.Celular = clienteViewModel.Celular;
                    cliente.Email = clienteViewModel.Email;
                    cliente.Endereco = clienteViewModel.Endereco;
                    cliente.Numero = clienteViewModel.Numero;
                    cliente.Complemento = clienteViewModel.Complemento;
                    cliente.Cep = clienteViewModel.Cep;
                    cliente.Cidade = clienteViewModel.Cidade;
                    cliente.UF = clienteViewModel.UF;


                    bll.Alterar(cliente);
                    return RedirectToAction("Index");



                }
                return View(clienteViewModel);
            }
        [Authorize]
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


        [Authorize]
        public ActionResult Incluir()
            {
                var cli = new ClienteViewModel();
                return View(cli);
            }
            [HttpPost]
            public ActionResult Incluir(ClienteViewModel clienteViewModel)
            {
                if (string.IsNullOrEmpty(clienteViewModel.Nome))
                {
                    ModelState.AddModelError("Nome", "O nome deve ser informado");
                }
                if (ModelState.IsValid)
                {
                    Cliente cliente;
                    if (clienteViewModel.Tipo == PessoaFisicaJuridica.PessoaFisica)
                    {
                        cliente = new Pessoa();
                        ((Pessoa)cliente).RG = clienteViewModel.RG;
                        ((Pessoa)cliente).CPF = clienteViewModel.CPF;
                        ((Pessoa)cliente).DataNascimento = clienteViewModel.DataNascimento;
                        cliente.Tipo = PessoaFisicaJuridica.PessoaFisica;

                    }
                    else
                    {
                        cliente = new Empresa();
                        ((Empresa)cliente).CNPJ = clienteViewModel.CNPJ;
                        cliente.Tipo = PessoaFisicaJuridica.PessoaJuridica;
                    }
                    cliente.Id = Guid.NewGuid().ToString();
                    cliente.Nome = clienteViewModel.Nome;
                    cliente.Telefone = clienteViewModel.Telefone;
                    cliente.Celular = clienteViewModel.Celular;
                    cliente.Email = clienteViewModel.Email;
                    cliente.Endereco = clienteViewModel.Endereco;
                    cliente.Numero = clienteViewModel.Numero;
                    cliente.Complemento = clienteViewModel.Complemento;
                    cliente.Cep = clienteViewModel.Cep;
                    cliente.Cidade = clienteViewModel.Cidade;
                    cliente.UF = clienteViewModel.UF;


                    bll.Incluir(cliente);
                    return RedirectToAction("Index");



                }
                return View(clienteViewModel);
            }
        }
    
}