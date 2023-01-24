namespace cdf_api_integrador.DTOs;

public record ClientDTO
{
    public string Nome {get;set;} = default!;
    public string Telefone {get;set;} = default!;
    public string Email {get;set;} = default!;
    public string Cpf {get;set;} = default!;
    public int EnderecoId {get;set;}= default!;
}