namespace cdf_api_integrador.DTOs;

public record OrderDTO
{
     public int Cliente_Id {get;set;} = default!;
    public decimal ValorTotal {get;set;} = default!;
    public DateTime DtCriacao {get;set;} = default!;
}