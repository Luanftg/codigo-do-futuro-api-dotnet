namespace cdf_api_integrador.Models;

public record PosicoesProduto
{
    int Id {get;set;}= default!;
    int Campanha_Id {get;set;} = default!;
    decimal Produto_Id {get;set;} = default!;
    int PosicaoX {get;set;} = default!;
    int PosicaoY {get;set;} = default!;

}