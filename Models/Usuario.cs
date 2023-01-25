using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

[Table("usuarios")]
public record Usuario
{
    [Key]
    public int Id {get;set;}= default!;
    public string Email {get;set;} = default!;
    public string Senha {get;set;} = default!;
    public string Regra {get;set;} = default!;
    public string Nome {get;set;} = default!;
}


