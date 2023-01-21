using cdf_api_integrador.DTOs;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("campanha")]
public class CampanhasController : ControllerBase
{
    private IRepository<Campanha> _repository;
    public CampanhasController(IRepository<Campanha> repository)
    {
        _repository = repository;
    }
    // GET: Campanha
    // [Logged]
    [HttpGet("/campanha")]
    public async Task<IActionResult> Index()
    {
        var campanha = await _repository.TodosAsync();
        return StatusCode(200, campanha);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var campanha = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, campanha);
    }
    
    // Post: Campanha
    // [Logged]
    [HttpPost("/campanha")]
    public async Task<IActionResult> Create([FromBody] CampainDTO campainDTO)
    {
        var campanha = BuilderService<Campanha>.Builder(campainDTO);
        await _repository.IncluirAsync(campanha);
        return StatusCode(201, campanha);
    }
    
    // Put: Campanha
    // [Logged]
    [HttpPut("/campanha/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Campanha campanha)
    {

        if(id != campanha.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do campanha precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(campanha);
        return StatusCode(200, campanha);
    }
    
    // Delete: Campanha
    // [Logged]
    [HttpDelete("/campanha/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var campanha = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(campanha is null)
        {
            return StatusCode(404, new {Mensagem = "O campanha informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(campanha);
        return StatusCode(204);
    }
}