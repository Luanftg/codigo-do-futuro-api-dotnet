using cdf_api_integrador.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace cdf_api_integrador.Controllers
{
    [Route("")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        // Post: Administrador
        [HttpGet]
        public IActionResult Index()
        {
            return StatusCode(200, new Home{Message =  "Bem vindo a API Radar - Código do Futuro - digite: '/swagger na url para acessar um modelo de visualização da API'"});
        }

    }     
}