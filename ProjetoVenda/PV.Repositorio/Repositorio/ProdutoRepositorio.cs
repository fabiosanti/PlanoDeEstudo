using Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using PV.Entity.Model;
using PV.Repositorio.Contexto;

namespace PV.Repositorio.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private DBContexto _context;

        public ProdutoRepositorio(DBContexto contexto) { _context = contexto; }

        public void Cadastrar(Produto produto)
        {
            _context.Add(produto);
        }

        public async Task<Produto> Pesquisar(Produto produto)
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsQueryable();

            if(produto.Produto_Id > 0)
                query = query.Where(p => p.Produto_Id == produto.Produto_Id);

            else
                query = query.Where(p =>p.Produto_Nome.Equals(produto.Produto_Nome));

            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<Produto>> Listar(Produto produto)
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsQueryable();

            if(produto.TipoProduto == 0)
                return await query.ToListAsync();

            query = query.Where(p => p.TipoProduto == produto.TipoProduto);

            return await query.ToListAsync();
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            return await _context.Produto
                .Where(p => p.Produto_Id == produto.Produto_Id)
                .ExecuteUpdateAsync(set => set
                    .SetProperty(p => p.Produto_Nome, produto.Produto_Nome)
                    .SetProperty(p => p.Produto_Preco, produto.Produto_Preco)
                    .SetProperty(p => p.Produto_QtdEstoque, produto.Produto_QtdEstoque)
                    .SetProperty(p => p.Produto_Descricao, produto.Produto_Descricao)
                    .SetProperty(p => p.Produto_DataCadastro, produto.Produto_DataCadastro)
            ) > 0;
                ;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
