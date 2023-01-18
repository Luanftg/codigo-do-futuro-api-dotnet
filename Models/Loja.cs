namespace cdf_api_integrador.Models;

public record Loja
{
    int Id {get;set;}= default!;
    string Nome {get;set;} = default!;
    int Endereco_id {get;set;} = default!;
    string? Latitude {get;set;} = default!;
    string? Longitude {get;set;} = default!;

}