using PV.Entity.Model;

namespace PV.Entity.Response
{
    public class ProdutoResponse : BaseResponse
    {
        public Produto Produto { get; set; }

        public ProdutoResponse(Produto produto, bool isSucess, string message): base(isSucess, message)
        {
            Produto = produto;
        }

        public ProdutoResponse(Produto produto) : this(produto, true, string.Empty) { }
        public ProdutoResponse(string message): this(null, false, message) { }

    }
}
