using cdf_api_integrador.DTOs;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("produto")]
public class ProdutoController : ControllerBase
{
    private IRepository<Produto> _repository;
    public ProdutoController(IRepository<Produto> repository)
    {
        _repository = repository;
    }
    // GET: Veiculos
    // [Logged]
    [HttpGet("/produtos")]
    public async Task<IActionResult> Index()
    {
        var produto = await _repository.TodosAsync();
        return StatusCode(200, produto);
    }

     [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var produto = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, produto);
    }
    
    // Post: Veiculos
    // [Logged]
    [HttpPost("/produtos")]
    public async Task<IActionResult> Create([FromBody] ProductDTO produtoDTO)
    {
        var produto = BuilderService<Produto>.Builder(produtoDTO);
        await _repository.IncluirAsync(produto);
        return StatusCode(201, produto);
    }
    
    // Put: Veiculos
    // [Logged]
    [HttpPut("/produtos/{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Produto produto)
    {

        if(id != produto.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(produto);
        return StatusCode(200, produto);
    }
    
    // Delete: Veiculos
    // [Logged]
    [HttpDelete("/produtos/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var produto = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(produto is null)
        {
            return StatusCode(404, new {Mensagem = "O produto informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(produto);
        return StatusCode(204);
    }
}