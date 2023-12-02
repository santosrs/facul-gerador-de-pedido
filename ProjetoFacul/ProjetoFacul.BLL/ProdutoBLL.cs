using ProjetoFacul.Models;
using ProjetoFacul.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.BLL
{
    public class ProdutoBLL : IProdutoDados

    {
        private IProdutoDados dal;
        public ProdutoBLL(IProdutoDados produtosDados)
        {
            this.dal = produtosDados;
        }
        

        public void Alterar(Produto produto)
        {
            Confirmar(produto);
            if (string.IsNullOrEmpty(produto.Id))
            {
                throw new Exception("O id deve ser informado");
            }

            dal.Alterar(produto);

        }

        public void Excluir(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("O id deve ser informado");
            }
            dal.Excluir(id);
        }

        public void Incluir(Produto produto)
        {
            Confirmar(produto);
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

        

        public IEnumerable<Produto> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
        private static void Confirmar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                throw new ApplicationException("O nome deve ser informado");
            }
        }
    }
}
