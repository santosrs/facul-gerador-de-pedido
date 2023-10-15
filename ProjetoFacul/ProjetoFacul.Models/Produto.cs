using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models
{
    public class Produto
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Fornecedor { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }


    }
}
