using cdf_api_integrador.ModelView;
using cdf_api_integrador.DTOs;
using Jose;

namespace cdf_api_integrador.Services.Autenticacao;

public class TokenJWT
{
    public static string Builder(UserLogged AdministradorLogado)
    {
        var key = "SEGREDO_do_CoDigoDO-Futuro";

        var payload = new UserJwtDTO
        {
           Id = AdministradorLogado.Id,
           Email = AdministradorLogado.Email,
           Regra = AdministradorLogado.Regra,
           Expiracao = DateTime.Now.AddDays(2)
        };

        string token = Jose.JWT.Encode(payload, key, JwsAlgorithm.none);

        return token;
    }

}