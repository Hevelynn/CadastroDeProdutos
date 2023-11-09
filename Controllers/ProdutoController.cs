using CadastrosDeProdutos.Models;
using CadastrosDeProdutos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosDeProdutos.Controllers
{
    [Route("v1/Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        [Route("CadastrarProduto")]
        public bool CadastrarProduto(Produto produto)
        { 
           return _produtoService.CadastrarProduto(produto);
        }

        // criar rota que retorna uma lista de produtos e chamar o ProdutoService.
        [HttpGet]
        [Route("ConsultarProdutos")]
        public List<Produto> GetProdutos()
        {
            return _produtoService.ConsulteLista();
        }

        [HttpGet]
        [Route("ConsultarProdutosPorCategoria")]

        public List<Produto> GetProduto(int codigo)
        {
            return _produtoService.ConsultePorCategoria(codigo);
        }

        [HttpPost]
        [Authorize]
        [Route("AtualizarProduto")]
        public IActionResult AtualizarProduto(Produto produto)
        {

            if (ModelState.IsValid)
            {
                Produto produtoAtualizado = _produtoService.AtualizarProduto(produto);

                if (produtoAtualizado != null)
                {
                    return ((IActionResult)produtoAtualizado);
                }

                return BadRequest("Erro ao atualizar pessoa, pessoa não encontrada.");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("ExcluirProduto")]
        public IActionResult ExcluirProduto(int codigo)
        {
            bool produtoExcluido = _produtoService.Excluir(codigo);

            if (produtoExcluido)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Produto não encontrado!");
            }
        }
    }
}
