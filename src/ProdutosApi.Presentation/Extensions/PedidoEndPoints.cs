using ProdutosApi.Application.DTOs;
using ProdutosApi.Application.Handlers;
using Wolverine;

namespace ProdutosApi.Presentation.Extensions
{
    public static class PedidoEndPoints
    {
        public static void MapPedidoEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/pedidos");

            // O endpoint chama o Mediator (Wolverine) de forma limpa
            group.MapGet("/", async (IMessageBus bus, CancellationToken ct) =>
            {
                var resultado = await bus.InvokeAsync<IReadOnlyCollection<PedidoResponse>>(new ListarPedidosQuery(), ct);
                return Results.Ok(resultado);
            });
        }
    }
}
