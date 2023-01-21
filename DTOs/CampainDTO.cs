namespace cdf_api_integrador.DTOs;

public record CampainDTO
{
    public int Loja_Id {get;set;} =default!;
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime Dt_Criacao {get;set;} = default!;
    public string Photo_Url {get;set;} = default!;
}