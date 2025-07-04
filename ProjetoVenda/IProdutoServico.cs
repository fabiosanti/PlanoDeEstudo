using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProdutoServico
{
    Task<ProdutoResponse> Cadastrar(Produto produto);
    Task<ProdutoResponse> Pesquisar(Produto produto);
    Task<List<Produto>> Listar(Produto produto)
}
