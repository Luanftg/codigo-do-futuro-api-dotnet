namespace cdf_api_integrador.DTOs;

public record ProductDTO
{
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public decimal Valor {get;set;} = default!;
    public int QtdEstoque {get;set;} = default!;
    public string PhotoUrl {get;set;} = default!;
}