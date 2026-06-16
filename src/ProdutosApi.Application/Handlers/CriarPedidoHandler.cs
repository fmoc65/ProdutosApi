using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces;

namespace ProdutosApi.Application.Handlers;

public static class CriarPedidoHandler
{
    public static async ValueTask Handle(
        CriarPedidoCommand command,
        IPedidoRepository repository,
        CancellationToken cancellation)
    {
        var novopedido = new Pedido
        {
            Id = Guid.NewGuid().ToString(),
            ClienteNome = command.ClienteNome,
            ProdutoNome = command.ProdutoNome,
            Quantidade = command.Quantidade,
            ValorTotal = command.ValorTotal
        };

        await repository.InserirPedido(novopedido, cancellation);
    }

}
