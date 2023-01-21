namespace cdf_api_integrador;

public record UserLoginDTO
{
    public string Email {get;set;} = default!;
    public string Senha {get;set;} = default!;
}