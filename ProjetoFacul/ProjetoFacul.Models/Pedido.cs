using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set;}
        public Cliente Cliente { get; set;}
        public List<Item> Itens { get; set; }
        public List<End> Ends { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public class Item
        {
            public int Ordem { get; set; }
            public  Produto Produto { get; set; }
            public int Quantidade { get; set; }
            public decimal Preco { get; set; }

        }
        public class End
        {
            public string Endereco { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Cep { get; set; }
            public string Cidade { get; set; }
            public string UF { get; set; }
        }

    }
}
