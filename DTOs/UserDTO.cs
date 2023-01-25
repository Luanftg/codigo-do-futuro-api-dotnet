namespace cdf_api_integrador;

public record UserDTO
{
    public string Email {get;set;} = default!;
    public string Senha {get;set;} = default!;
    public string Regra {get;set;} = default!;
    public string Nome {get;set;} = default!;
}