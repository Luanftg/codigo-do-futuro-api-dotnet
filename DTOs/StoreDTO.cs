namespace cdf_api_integrador.DTOs;

public record StoreDTO
{
    public string Nome {get;set;} = default!;
    public int EnderecoId {get;set;} = default!;
}