using ProdutosApi.Application.DTOs;
using ProdutosApi.Application.Mappers;
using ProdutosApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApi.Application.Handlers;

public record ListarPedidosQuery;
public class ListarPedidosHandler

{
    protected ListarPedidosHandler()
    {        
    }

    // O Wolverine injeta automaticamente o repositório e o mapper nos parâmetros do método estático
    public static async ValueTask<IReadOnlyCollection<PedidoResponse>> Handle(
        ListarPedidosQuery query,
        IPedidoRepository repository,
        PedidoMapper mapper,
        CancellationToken cancellationToken)
    {
        // Busca os dados através da abstração do repositório
        var pedidos = await repository.ListarTodosAsync(cancellationToken);

        // Mapeia para o DTO usando o Mapperly (sem reflexão)
        return mapper.ToResponseList(pedidos);
    }
}
