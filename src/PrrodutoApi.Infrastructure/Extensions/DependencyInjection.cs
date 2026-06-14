using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Produtos.Application.Mappers;
using ProdutosApi.Domain.Interfaces;
using PrrodutoApi.Infrastructure.Repositories;

namespace PrrodutoApi.Infrastructure.Extensions;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuração do MongoDB
        var mongoSettings = configuration.GetSection("MongoSettings");

        // 1. Instancia o cliente diretamente
        var client = new MongoClient(mongoSettings["ConnectionString"]);
        services.AddSingleton<IMongoClient>(client);

        // 2. SOLUÇÃO DEFINITIVA: Resolve a instância do Database AGORA e registra diretamente.
        // Sem funções anônimas (lambdas), eliminando o erro de Service Location do Wolverine.
        var database = client.GetDatabase(mongoSettings["DatabaseName"]);
        services.AddSingleton<IMongoDatabase>(database);

        // 3. O Repositório continua Scoped ou pode ser Transient/Singleton
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        // 4. Registro do Mapper do Mapperly
        services.AddSingleton<PedidoMapper>();

        return services;
    }
}

