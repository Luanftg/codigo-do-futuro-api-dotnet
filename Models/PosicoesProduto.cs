using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cdf_api_integrador.Models;

[Table("posicoes-produtos")]
public record PosicoesProduto
{
    [Key]
    public int Id {get;set;}= default!;
    public int Campanha_Id {get;set;} = default!;
    public decimal Produto_Id {get;set;} = default!;
    public int PosicaoX {get;set;} = default!;
    public int PosicaoY {get;set;} = default!;

}