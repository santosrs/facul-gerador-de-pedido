using ProjetoFacul.Models;
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
            DbHelper.ExecuteNonQuery("ProdutoAlterar",
                "@Id", produto.Id,
                "@Nome", produto.Nome,
                "@Fornecedor", produto.Fornecedor,
                "@Preco", produto.Preco,
                "@Estoque", produto.Estoque


                );
        }

        public void Excluir(string Id)
        {
            DbHelper.ExecuteNonQuery("ProdutoExcluir", "@Id", Id);


                
        }

        public void Incluir(Produto produto)
        {
            DbHelper.ExecuteNonQuery("ProdutoIncluir",
                "@Id", produto.Id,
                "@Nome", produto.Nome,
                "@Fornecedor", produto.Fornecedor,
                "@Preco", produto.Preco,
                "@Estoque", produto.Estoque
                

                );
        }

        public Produto ObterPorId(string id)
        {
            Produto produto = null;
            using (var reader = DbHelper.ExecuteReader("ProdutoObterPorId", "@Id", id))
            {
                if (reader.Read())
                {
                    produto = ObterProdutoReader(reader);

                }
            }
            return produto;
        }

        public List<Produto> ObterTodos()
        {
            var lista = new List<Produto>();
            using (var reader = DbHelper.ExecuteReader("ProdutoListar"))
            {
                while (reader.Read())
                {
                    Produto produto = ObterProdutoReader(reader);

                    lista.Add(produto);
                }
            }
            return lista;
        }

        private static Produto ObterProdutoReader(System.Data.IDataReader reader)
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
