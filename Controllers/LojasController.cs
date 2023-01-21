using cdf_api_integrador.DTOs;
using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class LojasController : ControllerBase
{
    private IRepository<Loja> _repository;
    public LojasController(IRepository<Loja> repository)
    {
        _repository = repository;
    }
    // GET: Veiculos
    [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var loja = await _repository.TodosAsync();
        return StatusCode(200, loja);
    }
    [Logged]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var loja = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, loja);
    }
    
    // Post: Veiculos
    [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StoreDTO lojaDTO)
    {
        var loja = BuilderService<Loja>.Builder(lojaDTO);
        await _repository.IncluirAsync(loja);
        return StatusCode(201, loja);
    }
    
    // Put: Veiculos
    [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Loja loja)
    {

        if(id != loja.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(loja);
        return StatusCode(200, loja);
    }
    
    // Delete: Veiculos
    [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var loja = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(loja is null)
        {
            return StatusCode(404, new {Mensagem = "O loja informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(loja);
        return StatusCode(204);
    }
}