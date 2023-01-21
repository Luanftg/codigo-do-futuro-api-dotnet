namespace cdf_api_integrador.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pedidos-produtos")]
public record PedidoProduto
{
    [Key]
    public int Id {get;set;} = default!;
    public int ProdutoId {get;set;} = default!;
    public Produto? Produto {get;set;}
    public int PedidoId {get;set;} = default!;
    public Pedido? Pedido {get;set;}
    public int Quantidade {get;set;} = default!;
    public decimal Valor {get;set;} = default!;
}