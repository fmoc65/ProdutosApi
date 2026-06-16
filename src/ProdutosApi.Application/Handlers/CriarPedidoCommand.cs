using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutosApi.Application.Handlers;

public record CriarPedidoCommand(
    string ClienteNome,
    string ProdutoNome,
    int Quantidade,
    decimal ValorTotal);
