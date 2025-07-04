using PV.Entity.Model;

namespace Interfaces.Repositorio
{
    public interface IProdutoRepositorio
    {
        void Cadastrar(Produto produto);
        Task<Produto> Pesquisar(Produto produto);
        Task<List<Produto>> Listar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<bool> SaveChanges();
    }
}
