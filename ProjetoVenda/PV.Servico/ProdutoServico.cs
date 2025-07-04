using Interfaces.Servicos;
using PV.Entity.Model;
using PV.Entity.Response;
using PV.Repositorio.Repositorio;

namespace PV.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private ProdutoRepositorio _repositorio;

        public ProdutoServico(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ProdutoResponse> Cadastrar(Produto produto)
        {
            var produtoRepositorio = await _repositorio.Pesquisar(produto);

            if (produtoRepositorio != null)
                if(produtoRepositorio.Produto_Nome.Equals(produto.Produto_Nome) 
                    && produtoRepositorio.TipoProduto == produto.TipoProduto)
                        return new ProdutoResponse("Já existe produto cadastrado com este nome na Categoria");

            _repositorio.Cadastrar(produto);

            if(await _repositorio.SaveChanges())
                return new ProdutoResponse(produto);

            return new ProdutoResponse("Ocorreu um erro ao cadastrar Produto");
        }

        public async Task<ProdutoResponse> Pesquisar(Produto produto)
        {
            var produtoRepositorio = await _repositorio.Pesquisar(produto);

            if (produtoRepositorio != null)
                return new ProdutoResponse(produtoRepositorio);

            return new ProdutoResponse("Produto não localizado");
        }

        public async Task<List<Produto>> Listar(Produto produto)
        {
            return await _repositorio.Listar(produto);
        }

        public async Task<ProdutoResponse> Atualizar(Produto produto)
        {
            if (await _repositorio.Atualizar(produto))
                return new ProdutoResponse(produto);

            return new ProdutoResponse("Erro ao atualizar o produto");
        }
    }
}
