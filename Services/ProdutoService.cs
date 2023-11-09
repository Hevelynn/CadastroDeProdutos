using CadastrosDeProdutos.Models;
using CadastrosDeProdutos.Repository;

namespace CadastrosDeProdutos.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public bool CadastrarProduto(Produto produto)
        {
            return _produtoRepository.CadastrarProduto(produto);
        }

        // criar consulteLista que retorna uma lista de produtos e chamar repository
        public List<Produto> ConsulteLista()
        {
           return _produtoRepository.ConsulteLista();
        }

        public List<Produto> ConsultePorCategoria(int codigo)
        {
            return _produtoRepository.ConsultePorCategoria(codigo);
        }

        public Produto AtualizarProduto(Produto produto)
        {
            return _produtoRepository.AtualizarProduto(produto);
        }

        public bool Excluir(int codigo)
        {
            return _produtoRepository.Excluir(codigo);
        }
    }
}
