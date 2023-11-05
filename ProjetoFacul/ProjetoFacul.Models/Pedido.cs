using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFacul.Models
{
    public class Pedido
    {
        public Pedido()
        {
            this.Items = new List<Item>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set;}
        public Cliente Cliente { get; set;}
        public List<Item> Items { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public class Item
        {
            public int Ordem { get; set; }
            public  Produto Produto { get; set; }
            public int Quantidade { get; set; }
            public decimal Preco { get; set; }

        }
        

    }
}
