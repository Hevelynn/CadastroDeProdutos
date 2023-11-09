using CadastrosDeProdutos.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastrosDeProdutos.Repository
{
    public class ProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public ProdutoRepository()
        {
            PopularProdutos();
        }


        public bool CadastrarProduto(Produto produto)
        {
            _produtos.Add(produto);
            if (_produtos.Any(x => x.Nome == produto.Nome)) return true;
            return false;
        }

        // criar método que consulte lista e que retorne uma lista de produtos
        public List<Produto> ConsulteLista()
        {
            return _produtos.ToList();
        }

        public List<Produto> ConsultePorCategoria(int codigo)
        {
            return _produtos.Where(x => x.Categoria.Codigo == codigo).ToList();
        }

        public Produto AtualizarProduto(Produto produto)
        {
            var produtoExistente = _produtos.FirstOrDefault(x => x.Nome == produto.Nome);

            if (produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Valor = produto.Valor;
                produtoExistente.Descricao = produto.Descricao;
                produtoExistente.Categoria = produto.Categoria;

                produtoExistente.Categoria.Codigo = produto.Categoria.Codigo;
                produtoExistente.Categoria.Nome = produto.Categoria.Nome;

                return produtoExistente;
            }

            return null;
        }

        public bool Excluir(int codigo)
        {
            var produtoParaExcluir = _produtos.FirstOrDefault(x => x.Categoria.Codigo == codigo); ;

            if(produtoParaExcluir != null)
            {
                _produtos.Remove(produtoParaExcluir);

                return true;
            }

            return false;
        }

        private void PopularProdutos() 
        {
            Categoria categoria1 = new Categoria();
            categoria1.Codigo = 1;
            categoria1.Nome = "Cadeira";     
            
            Categoria categoria2 = new Categoria();
            categoria2.Codigo = 2;
            categoria2.Nome = "Guarda-rouoa"; 
            
            Categoria categoria3 = new Categoria();
            categoria3.Codigo = 3;
            categoria3.Nome = "Mesa";            
            
            Categoria categoria4 = new Categoria();
            categoria4.Codigo = 4;
            categoria4.Nome = "Armário";

            Produto produto1 = new Produto(categoria1, "Cadeira", 200, "Amarela");
            _produtos.Add(produto1);
            Produto produto2 = new Produto(categoria4, "Armário", 150, "Branco");
            _produtos.Add(produto2);
            Produto produto3 = new Produto(categoria3, "Mesa", 250, "Vermelha");
            _produtos.Add(produto3);
            Produto produto4 = new Produto(categoria2, "Guarda-roupa", 350, "Azul");
            _produtos.Add(produto4);
        }
    }
}
