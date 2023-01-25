using cdf_api_integrador.DTOs;
using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class PedidosController : ControllerBase
{
    private IRepository<Pedido> _repository;
    public PedidosController(IRepository<Pedido> repository)
    {
        _repository = repository;
    }
    // GET: Pedidos
    [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pedido = await _repository.TodosAsync();
        return StatusCode(200, pedido);
    }
    [Logged]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var pedido = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, pedido);
    }
    
    // Post: Pedidos
    [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderDTO orderDTO)
    {
        var pedido = BuilderService<Pedido>.Builder(orderDTO);
        await _repository.IncluirAsync(pedido);
        return StatusCode(201, pedido);
    }
    
    // Put: Pedidos
    [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Pedido pedido)
    {

        if(id != pedido.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do pedido precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(pedido);
        return StatusCode(200, pedido);
    }
    
    // Delete: Pedidos
    [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var pedido = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(pedido is null)
        {
            return StatusCode(404, new {Mensagem = "O pedido informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(pedido);
        return StatusCode(204);
    }
}