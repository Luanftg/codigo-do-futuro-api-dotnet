namespace cdf_api_integrador.Models;

public record Loja
{
    int Id {get;set;}= default!;
    string Nome {get;set;} = default!;
    string Observacao {get;set;} = default!;
    int Endereco_id {get;set;} = default!;
    decimal ValorTotal {get;set;} = default!;
    DateTime DtCriacao {get;set;} = default!;
    string Latitude {get;set;} = default!;
    string Longitude {get;set;} = default!;

}