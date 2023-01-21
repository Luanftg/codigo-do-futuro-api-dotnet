using cdf_api_integrador.DTOs;
using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class PedidoProdutoController : ControllerBase
{
    private IRepository<PedidoProduto> _repository;
    public PedidoProdutoController(IRepository<PedidoProduto> repository)
    {
        _repository = repository;
    }
    // GET: PedidoProdutos
    [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var pedidoProduto = await _repository.TodosAsync();
        return StatusCode(200, pedidoProduto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var pedidoProduto = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, pedidoProduto);
    }
    
    // Post: PedidoProdutos
    [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrderProductDTO orderProductDTO)
    {
        var pedidoProduto = BuilderService<PedidoProduto>.Builder(orderProductDTO);
        await _repository.IncluirAsync(pedidoProduto);
        return StatusCode(201, pedidoProduto);
    }
    
    // Put: PedidoProdutos
    [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PedidoProduto pedidoProduto)
    {

        if(id != pedidoProduto.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(pedidoProduto);
        return StatusCode(200, pedidoProduto);
    }
    
    // Delete: PedidoProdutos
    [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var pedidoProduto = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(pedidoProduto is null)
        {
            return StatusCode(404, new {Mensagem = "O pedidoProduto informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(pedidoProduto);
        return StatusCode(204);
    }
}