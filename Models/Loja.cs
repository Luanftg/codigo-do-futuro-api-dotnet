using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

[Table('lojas')]
public record Loja
{
    [Key]
    public int Id {get;set;}= default!;
    public string Nome {get;set;} = default!;
    public int EnderecoId {get;set;} = default!;
    public string? Latitude {get;set;} = default!;
    public string? Longitude {get;set;} = default!;
    public Endereco? Endereco {get;set;}
}