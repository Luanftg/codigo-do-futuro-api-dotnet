namespace cdf_api_integrador.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pedidos-produtos")]
public record PedidoProduto
{
    [Key]
    public int Id {get;set;} = default!;
    public int Produto_Id {get;set;} = default!;
    public int Quantidade {get;set;} = default!;
    public decimal Valor {get;set;} = default!;
    public int Pedido_Id {get;set;} = default!;
}