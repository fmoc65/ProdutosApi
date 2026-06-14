using ProdutosApi.Domain.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Application.DTOs;

public record PedidoResponse(
    string Id,
    string ClienteNome,
    string ProdutoNome,
    int Quantidade,
    decimal ValorTotal
);

