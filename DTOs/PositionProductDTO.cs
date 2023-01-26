namespace cdf_api_integrador.DTOs;

public record PositionProductDTO
{
    public int CampanhaId {get;set;} = default!;
    public int ProdutoId {get;set;} = default!;
    public int PosicaoX {get;set;} = default!;
    public int PosicaoY {get;set;} = default!;
}