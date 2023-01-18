using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

public record Loja
{
    [Key]
    public int Id {get;set;}= default!;
    public string Nome {get;set;} = default!;
    public int Endereco_id {get;set;} = default!;
    public string? Latitude {get;set;} = default!;
    public string? Longitude {get;set;} = default!;

}