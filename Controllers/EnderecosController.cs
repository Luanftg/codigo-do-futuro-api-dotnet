using cdf_api_integrador.DTOs;
using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class EnderecosController : ControllerBase
{
    private IRepository<Endereco> _repository;
    public EnderecosController(IRepository<Endereco> repository)
    {
        _repository = repository;
    }
    // GET: Enderecos
    [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var endereco = await _repository.TodosAsync();
        return StatusCode(200, endereco);
    }
    [Logged]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var endereco = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, endereco);
    }
    
    // Post: Enderecos
    [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AdressDTO addressDTO)
    {
        var endereco = BuilderService<Endereco>.Builder(addressDTO);
        await _repository.IncluirAsync(endereco);
        return StatusCode(201, endereco);
    }
    
    // Put: Enderecos
    [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Endereco endereco)
    {

        if(id != endereco.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(endereco);
        return StatusCode(200, endereco);
    }
    
    // Delete: Enderecos
    [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var endereco = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(endereco is null)
        {
            return StatusCode(404, new {Mensagem = "O endereco informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(endereco);
        return StatusCode(204);
    }
}