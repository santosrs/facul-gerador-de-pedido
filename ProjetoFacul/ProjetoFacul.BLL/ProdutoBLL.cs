using ProjetoFacul.Models;
using ProjetoFacul.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.BLL
{
    public class ProdutoBLL : IProdutoDados

    {
        private ProdutoDAL dal;

        public ProdutoBLL()
        {
            this.dal = new ProdutoDAL();
        }
        public void Alterar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Id))
            {
                throw new Exception("O id deve ser informado");
            }
            dal.Alterar(produto);
        }

        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O id deve ser informado");
            }
            dal.Excluir(Id);
        }

        public void Incluir(Produto produto)
        {
            Validar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                produto.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(produto);
        }

        public Produto ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }
        private static void Validar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                throw new ApplicationException("O nome deve ser informado");
            }
        }
        private static Produto ObterClienteReader(System.Data.IDataReader reader)
        {
            var produto = new Produto();
            produto.Id = reader["Id"].ToString();
            produto.Nome = reader["Nome"].ToString();
            produto.Fornecedor = reader["Fornecedor"].ToString();
            produto.Preco = Convert.ToDecimal(reader["Preco"]);
            produto.Estoque = Convert.ToInt32(reader["Estoque"]);
            return produto;
        }
    }
}
