namespace cdf_api_integrador.Models;

public record Usuario
{
    int Id {get;set;}= default!;
    string Email {get;set;} = default!;
    string Senha {get;set;} = default!;
    string Regra {get;set;} = default!;
    decimal Nome {get;set;} = default!;

}