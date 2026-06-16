using ProdutosApi.Application.Handlers;
using ProdutosApi.Presentation.Extensions;
using PrrodutoApi.Infrastructure.Extensions;

using Wolverine;

var builder = WebApplication.CreateBuilder(args);

// Configura a Infraestrutura (Mongo, Mappers, Dapper, etc)
builder.Services.AddInfrastructure(builder.Configuration);

// Configura o Wolverine como o Mediator/Service Bus da aplicação
builder.Host.UseWolverine(opts =>
{
    // Diz ao Wolverine para procurar Handlers no mesmo assembly onde a Query está
    opts.Discovery.IncludeAssembly(typeof(ListarPedidosQuery).Assembly);

});
var app = builder.Build();

app.UseHttpsRedirection();

// Mapeia as rotas sem expor a lógica aqui dentro
app.MapPedidoEndpoints();

await app.RunAsync();