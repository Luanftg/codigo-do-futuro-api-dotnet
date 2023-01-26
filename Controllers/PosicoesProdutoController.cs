using cdf_api_integrador.DTOs;
using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class PosicoesProdutosController : ControllerBase
{
    private IRepository<PosicoesProduto> _repository;
    public PosicoesProdutosController(IRepository<PosicoesProduto> repository)
    {
        _repository = repository;
    }
    // GET: PosicoesProdutos
    [Logged]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var posicoesProduto = await _repository.TodosAsync();
        return StatusCode(200, posicoesProduto);
    }
    
    [Logged]
    [HttpGet("{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var posicoesProduto = (await _repository.TodosAsync()).Find(c => c.Id == id);
        return StatusCode(200, posicoesProduto);
    }
    
    // Post: PosicoesProdutos
    [Logged]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PositionProductDTO positionProductDTO)
    {
        var posicoesProduto = BuilderService<PosicoesProduto>.Builder(positionProductDTO);
        await _repository.IncluirAsync(posicoesProduto);
        return StatusCode(201, posicoesProduto);
    }
    
    // Put: PosicoesProdutos
    [Logged]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PosicoesProduto posicoesProduto)
    {

        if(id != posicoesProduto.Id)
        {
            return StatusCode(400, new {Mensagem = "O Id do veículo precisa coincidir com o id passado pela url"});
        }
        
        await _repository.AtualizarAsync(posicoesProduto);
        return StatusCode(200, posicoesProduto);
    }
    
    // Delete: PosicoesProdutos
    [Logged]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var posicoesProduto = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

        if(posicoesProduto is null)
        {
            return StatusCode(404, new {Mensagem = "O posicoesProduto informado não existe na base de dados"});
        }
        
        await _repository.ApagarAsync(posicoesProduto);
        return StatusCode(204);
    }
}