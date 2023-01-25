using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

[Table('campanhas')]
public record Campanha
{
    [Key]
    public int Id {get;set;} = default!;
    public int LojaId {get;set;} =default!;
    public Loja? loja {get;set;} 
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public DateTime DtCriacao {get;set;} = default!;
    public string PhotoUrl {get;set;} = default!;
}