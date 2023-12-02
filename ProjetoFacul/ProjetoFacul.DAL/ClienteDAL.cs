using ProjetoFacul.Models;
using ProjetoFacul.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjetoFacul.DAL
{
    public class ClienteDAL : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            if (cliente is Empresa)
            {
                Db.Execute("ClienteEmpresaAlterar", cliente);
            }
            else
            {
                Db.Execute("ClientePessoaAlterar", cliente);
            }

        }

        public void Excluir(string id)
        {
            Db.Execute("ClienteExcluir", new { Id = id });
        }

        public void Incluir(Cliente cliente)
        {
            if (cliente is Empresa)
            {
                Db.Execute("ClienteEmpresaIncluir", cliente);
            }
            else
            {
                Db.Execute("ClientePessoaIncluir", cliente);
            }
               

        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id)
        {
            var cliente = Db.QueryEntidade<Cliente>("ClienteObterPorId", new { Id = id });

            if (cliente.Tipo == PessoaFisicaJuridica.PessoaJuridica)
            {
                var empresa = Db.QueryEntidade<Empresa>("ClienteObterPorId", new { Id = id });
                return empresa;
            }
            else
            {
                var pessoa = Db.QueryEntidade<Pessoa>("ClienteObterPorId", new { Id = id });
                return pessoa;
            }
        }

        

        public IEnumerable<Cliente> ObterTodos()
        {
            return Db.QueryColecao<Cliente>("ClienteListar", new {  });
        }

        

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }

     
}

  
