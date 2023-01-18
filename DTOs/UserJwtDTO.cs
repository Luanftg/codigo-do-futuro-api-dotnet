namespace cdf_api_integrador.DTOs;
public record UserJwtDTO
{
    public int Id { get;set; }
    public string Email { get;set; } = default!;
    public string Regra { get;set; } = default!;
    public DateTime Expiracao { get;set; } = default!;
}