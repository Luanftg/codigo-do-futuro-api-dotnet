using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

public record Endereco
{
    [Key]
    public int Id {get;set;}= default!;
    public string Cep {get;set;} = default!;
    public string Logradouro {get;set;} = default!;
    public string Numero {get;set;} = default!;
    public string Bairro {get;set;} = default!;
    public string Cidade {get;set;} = default!;
    public string Estado {get;set;} = default!;
    public string Complemento {get;set;} = default!;
}