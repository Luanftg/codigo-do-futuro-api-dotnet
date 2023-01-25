using System.ComponentModel.DataAnnotations;

namespace cdf_api_integrador.Models;

public record Pedido
{
    [Key]
    public int Id {get;set;}= default!;
    public int ClienteId {get;set;} = default!;
    public Cliente? Cliente {get;set;}
    public decimal ValorTotal {get;set;} = default!;
    public DateTime DtCriacao {get;set;} = default!;

}