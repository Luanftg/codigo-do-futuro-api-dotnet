namespace cdf_api_integrador.ModelView;

public record UserLogged
{
    public int Id { get;set; } = default!;
    public string Nome { get;set; } = default!;
    public string Email { get;set; } = default!;
    public string Regra { get;set; } = default!;
    public string Token { get;set; } = default!;
}