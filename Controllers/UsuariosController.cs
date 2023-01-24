using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Entity;
using cdf_api_integrador.Services;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Filters;

namespace cdf_api_integrador.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IRepositoryUser<Usuario>  _repository;

        public UsuariosController(IRepositoryUser<Usuario> repository)
        {
            _repository = repository;
        }
        
        [Logged]
        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var users = await _repository.TodosAsync();
            return StatusCode(200, users);
        }

        [Logged]
        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
               if(id != usuario.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(usuario);
        return StatusCode(200, usuario);
    
        }
        [Logged]
        // Post: Administrador
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
        {

            var hashPass = HashService.Hash(userDTO.Senha);
            userDTO.Senha = hashPass;
            var user = BuilderService<Usuario>.Builder(userDTO);
            await _repository.IncluirAsync(user);
            return StatusCode(201, user);
        }
        [Logged]
        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var user = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(user is null)
        {
            return StatusCode(404, new {Mensagem = "O user informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(user);
        return StatusCode(204);
    }
    }     
}