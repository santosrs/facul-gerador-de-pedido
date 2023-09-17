using ProjetoFacul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.DAL
{
    public class ClienteDAL : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteAlterar",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Telefone", cliente.Telefone,
                "@Celular", cliente.Celular,
                "@Email", cliente.Email,
                "@Endereco", cliente.Endereco,
                "@Numero", cliente.Numero,
                "@Complemento", cliente.Complemento,
                "@Cep", cliente.Cep,
                "@Cidade", cliente.Cidade,
                "@UF", cliente.UF

                );
        }

        public void Excluir(string Id)
        {
            DbHelper.ExecuteNonQuery("ClienteExcluir", "@Id", Id);
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteIncluir",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Telefone", cliente.Telefone,
                "@Celular", cliente.Celular,
                "@Email", cliente.Email,
                "@Endereco", cliente.Endereco,
                "@Numero", cliente.Numero,
                "@Complemento", cliente.Complemento,
                "@Cep", cliente.Cep,
                "@Cidade", cliente.Cidade,
                "@UF", cliente.UF

                );
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id)
        {
            Cliente cliente = null;
            using (var reader = DbHelper.ExecuteReader("ClienteObterPorId", "@Id", id))
            {
                if (reader.Read())
                {
                    cliente = ObterClienteReader(reader);

                }
            }
            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar"))
            {
                while (reader.Read())
                {
                    Cliente cliente = ObterClienteReader(reader);

                    lista.Add(cliente);
                }
            }
            return lista;
        }

        private static Cliente ObterClienteReader(System.Data.IDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Id = reader["Id"].ToString();
            cliente.Nome = reader["Nome"].ToString();            
            cliente.Telefone = reader["Telefone"].ToString();
            cliente.Celular = reader["Celular"].ToString();
            cliente.Email = reader["Email"].ToString();
            cliente.Endereco = reader["Endereco"].ToString();
            cliente.Numero = reader["Numero"].ToString();
            cliente.Complemento = reader["Complemento"].ToString();
            cliente.Cep = reader["Cep"].ToString();
            cliente.Cidade = reader["Cidade"].ToString();
            cliente.UF = reader["UF"].ToString();
            return cliente;
        }
    }
}
