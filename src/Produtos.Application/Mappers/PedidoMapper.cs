using Produtos.Application.DTOs;
using ProdutosApi.Domain.Entities;
using Riok.Mapperly.Abstractions;


namespace Produtos.Application.Mappers
{
    [Mapper]
    public partial class PedidoMapper
    {
        // 1. Diga ao Mapperly como mapear a LISTA
        public partial IReadOnlyCollection<PedidoResponse> ToResponseList(IEnumerable<Pedido> pedidos);
    }
}
