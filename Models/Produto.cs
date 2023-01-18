using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Model;

public record Produto
{
    [Key]
    public int Id {get;set;}= default!;
    public string Nome {get;set;} = default!;
    public string Descricao {get;set;} = default!;
    public decimal Valor {get;set;} = default!;
    public int QtdEstoque {get;set;} = default!;

}