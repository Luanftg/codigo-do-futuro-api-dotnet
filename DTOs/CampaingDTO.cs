using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

public record CampaingDTO
{
    public int LojaId {get;set;} =default!;
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime DtCriacao {get;set;} = default!;
    public string PhotoUrl {get;set;} = default!;
}