using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApi.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        ValueTask<IReadOnlyCollection<Pedido>> ListarTodosAsync(CancellationToken cancellationToken);

        ValueTask InserirPedido(Pedido pedido, CancellationToken cancellationToken);
    }
}
