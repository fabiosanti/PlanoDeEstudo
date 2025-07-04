using PV.Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace PV.Entity.Model
{
    public class Produto
    {
        [Key]
        public int Produto_Id { get; set; }
        public string Produto_Nome { get; set; }
        public int Produto_QtdEstoque { get; set; }
        public decimal Produto_Preco { get; set; }
        public string Produto_Descricao { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public DateTime Produto_DataCadastro { get; set; }
    }
}
