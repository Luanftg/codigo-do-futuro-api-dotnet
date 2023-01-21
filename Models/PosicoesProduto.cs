using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cdf_api_integrador.Models;

[Table("posicoes-produtos")]
public record PosicoesProduto
{
    [Key]
    public int Id {get;set;}= default!;
    public int CampanhaId {get;set;} = default!;
    public Campanha? Campanha {get;set;}
    public int ProdutoId {get;set;} = default!;
    public Produto? Produto {get;set;}
    public int PosicaoX {get;set;} = default!;
    public int PosicaoY {get;set;} = default!;

}