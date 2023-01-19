using cdf_api_integrador.DTOs;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private IRepository<Cliente> _repository;
    public ClientesController(IRepository<Cliente> repository)
    {
        _repository = repository;
    }
    // GET: Veiculos
    // [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var cliente = await _repository.TodosAsync();
        return StatusCode(200, cliente);
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var cliente = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, cliente);
    }
    
    // Post: Veiculos
    // [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientDTO clientDTO)
    {
        var cliente = BuilderService<Cliente>.Builder(clientDTO);
        await _repository.IncluirAsync(cliente);
        return StatusCode(201, cliente);
    }
    
    // Put: Veiculos
    // [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cliente cliente)
    {

        if(id != cliente.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(cliente);
        return StatusCode(200, cliente);
    }
    
    // Delete: Veiculos
    // [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var cliente = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(cliente is null)
        {
            return StatusCode(404, new {Mensagem = "O cliente informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(cliente);
        return StatusCode(204);
    }
}