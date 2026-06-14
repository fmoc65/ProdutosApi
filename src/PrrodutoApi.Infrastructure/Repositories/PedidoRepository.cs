using MongoDB.Driver;
using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrrodutoApi.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMongoCollection<Pedido> _collection;

        public PedidoRepository(IMongoDatabase database)
        {
            // Obtém a coleção uma única vez na construção do repositório
            _collection = database.GetCollection<Pedido>("Pedidos");
        }

        public async ValueTask<IReadOnlyCollection<Pedido>> ListarTodosAsync(CancellationToken cancellationToken)
        {
            // O ToListAsync do driver do Mongo já faz o streaming dos dados de forma eficiente
            var resultado = await _collection
                .Find(FilterDefinition<Pedido>.Empty)
                .ToListAsync(cancellationToken);

            return resultado;
        }
    }
}
