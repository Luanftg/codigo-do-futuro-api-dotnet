using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using cdf_api_integrador.Models;

using cdf_api_integrador.Services;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.ModelView;
using cdf_api_integrador.Services.Autenticacao;

namespace cdf_api_integrador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IRepositoryUser<Usuario> _repository;

        public LoginController(IRepositoryUser<Usuario> repository)
        {
            _repository = repository;
        }

        // Post: Administrador
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            if(string.IsNullOrEmpty(userLoginDTO.Email) || string.IsNullOrEmpty(userLoginDTO.Senha))
                return StatusCode(400, new {
                    Mensagem = "Preencha o email e a senha"
            });

            var user = await _repository.Login(userLoginDTO.Email, userLoginDTO.Senha);
            
            if(user is null)
                return StatusCode(404, new {
                    Mensagem = "Usuario ou senha não encontrado em nossa base de dados"
            });

            var userLogged = BuilderService<UserLogged>.Builder(user);
            userLogged.Token = TokenJWT.Builder(userLogged);
            return StatusCode(200, userLogged);
        }

    }     
}