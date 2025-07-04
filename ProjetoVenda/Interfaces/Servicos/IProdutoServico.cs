using PV.Entity.Model;
using PV.Entity.Response;

namespace Interfaces.Servicos
{
    public interface IProdutoServico
    {
        Task<ProdutoResponse> Cadastrar(Produto produto);
        Task<ProdutoResponse> Pesquisar(Produto produto);
        Task<List<Produto>> Listar(Produto produto);
        Task<ProdutoResponse> Atualizar(Produto produto);
    }
}
