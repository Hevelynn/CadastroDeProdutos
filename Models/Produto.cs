namespace CadastrosDeProdutos.Models;

public class Produto
{
    public Produto(Categoria categoria, string nome, int valor, string descricao)
    {
        Categoria = categoria;
        Descricao = descricao;
        Valor = valor;
        Nome = nome;
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Valor { get; set; }
    public Categoria Categoria { get; set; }
}
