namespace ProdutosApi.Domain.Entities;

public record Pedido
{
    public string Id { get; init; } = string.Empty;
    public string ClienteNome { get; init; } = string.Empty;
    public string ProdutoNome { get; init; } = string.Empty;
    public int Quantidade { get; init; }
    public decimal ValorTotal { get; init; }
    public DateTime DataPedido { get; init; }
}
