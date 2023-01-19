namespace cdf_api_integrador.DTOs;

public record OrderProductDTO
{
    public int Campanha_Id {get;set;} = default!;
    public decimal Produto_Id {get;set;} = default!;
    public int PosicaoX {get;set;} = default!;
    public int PosicaoY {get;set;} = default!;
}