using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema

namespace cdf_api_integrador.Models;

[Table("produtos")]
public record Produto
{
    [Key]
    public int Id {get;set;}= default!;
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public decimal Valor {get;set;} = default!;
    public int QtdEstoque {get;set;} = default!;
    public string PhotoUrl {get;set;} =default!;
}