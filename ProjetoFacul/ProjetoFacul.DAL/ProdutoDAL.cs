using ProjetoFacul.Models;
using ProjetoFacul.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.DAL
{
    public class ProdutoDAL : IProdutoDados

    {
        public void Alterar(Produto produto)
        {
            Db.Execute("ProdutoAlterar", produto);
        }

        public void Excluir(string id)
        {
            Db.Execute("ProdutoExcluir", new { Id = id });
        }

        public void Incluir(Produto produto)
        {
            Db.Execute("ProdutoIncluir", produto);
        }

        public Produto ObterPorId(string id)
        {
            return Db.QueryEntidade<Produto>("ProdutoObterPorId", new { Id = id });
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return Db.QueryColecao<Produto>("ProdutoListar", new { });
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}

