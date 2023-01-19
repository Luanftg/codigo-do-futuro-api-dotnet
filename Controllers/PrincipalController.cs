using cdf_api_integrador.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace cdf_api_integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        // Post: Administrador
        [HttpPost]
        public IActionResult Index()
        {
            return StatusCode(200, new Home{Message =  "Bem vindo a API Radar - Código do Futuro - grupo 2"});
        }

    }     
}