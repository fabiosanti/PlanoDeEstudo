using Interfaces.Repositorio;
using Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using PV.Entity.Model;

namespace ProjetoVenda.Controllers
{
    [Route("api/controller/")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private IProdutoServico _servico;
        private IProdutoRepositorio _repositorio;

        public ProdutoController(IProdutoServico servico, IProdutoRepositorio repositorio)
        {
            _servico = servico;
            _repositorio = repositorio;
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<Produto>> Cadastrar(Produto produto)
        {
            var response = await _servico.Cadastrar(produto);

            if(response.IsSucess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Pesquisar")]
        public async Task<ActionResult<Produto>> Pesquisar(Produto produto)
        {
            var response = await _servico.Pesquisar(produto);

            if (response.IsSucess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<List<Produto>>> Listar(Produto produto)
        {
            var response = await _servico.Listar(produto);

            if (response.Count > 0 )
                return Ok(response);

            return BadRequest("Produtos não localizados");
        }


        [HttpPut("Atualizar")]
        public async Task<ActionResult<Produto>> Atualizar(Produto produto)
        {
            var response = await _servico.Atualizar(produto);

            if (response.IsSucess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
