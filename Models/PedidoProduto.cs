public record PedidoProduto
{
    int Id {get;set;}= default!;
    int Produto_Id {get;set;} = default!;
    int Quantidade {get;set;} = default!;
    decimal Valor {get;set;} = default!;
    int Pedido_Id {get;set;} = default!;
}