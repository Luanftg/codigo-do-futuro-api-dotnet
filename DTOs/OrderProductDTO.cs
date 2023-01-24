namespace cdf_api_integrador.DTOs;

public record OrderProductDTO
{
    public int PedidoId {get;set;} = default!;
    public int ProdutoId {get;set;} = default!;
    public decimal valor {get;set;} = default!;
    public int quantidade {get;set;} = default!;

}