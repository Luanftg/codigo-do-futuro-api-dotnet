namespace cdf_api_integrador.Models;

public record Campanha
{
    int Id {get;set;} =default!;
    int Loja_Id {get;set;} =default!;
    string Nome {get;set;} = default!;
    string Descricao {get;set;} = default!;
    DateTime Dt_Criacao {get;set;} = default!;
    string Photo_Url {get;set;} = default!;
}