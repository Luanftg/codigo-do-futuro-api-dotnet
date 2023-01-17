namespace cdf_api_integrador.Models;

public record Pedido
{
    int Id {get;set;}= default!;
    int Cliente_Id {get;set;} = default!;
    decimal ValorTotal {get;set;} = default!;
    DateTime DtCriacao {get;set;} = default!;

}