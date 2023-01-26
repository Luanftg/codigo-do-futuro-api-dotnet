namespace cdf_api_integrador.DTOs;

public record CampainDTO
{
    public int LojaId {get;set;} =default!;
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime DtCriacao {get;set;} = default!;
    public string PhotoUrl {get;set;} = default!;
}