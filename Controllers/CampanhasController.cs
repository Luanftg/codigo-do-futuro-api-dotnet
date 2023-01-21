using cdf_api_integrador.Filters;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Interface;
using cdf_api_integrador.Services;

using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [Logged]
    [ApiController]
    public class CampanhasController : ControllerBase
    {
        private readonly IRepository<Campanha> _repository;

        public CampanhasController(IRepository<Campanha> repository)
        {
            _repository = repository;
        }

        // GET: api/Campanha
        // [Logged]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var campanha = await _repository.TodosAsync();
            return StatusCode(200, campanha);
        }
       
        // [Logged]
        [Permission(Nivel ="adm")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var campanha = (await _repository.TodosAsync()).Find(c => c.Id == id);
            return StatusCode(200, campanha);
        }
        
        // Post: Campanhas
        // [Logged]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CampaingDTO campaingDTO)
        {
            var campanha = BuilderService<Campanha>.Builder(campaingDTO);
            await _repository.IncluirAsync(campanha);
            return StatusCode(201, campanha);
        }
        
        // Put: Campanhas
        // [Logged]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Campanha campanha)
        {

            if(id != campanha.Id)
            {
                return StatusCode(400, new {Mensagem = "O Id da campanha precisa coincidir com o id passado pela url"});
            }
            
            await _repository.AtualizarAsync(campanha);
            return StatusCode(200, campanha);
        }
        
        // Delete: Campanhas
        // [Logged]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            var campanha = (await _repository.TodosAsync()).Find(v=>v.Id ==id);

            if(campanha is null)
            {
                return StatusCode(404, new {Mensagem = "A campanha informada não existe na base de dados"});
            }
            
            await _repository.ApagarAsync(campanha);
            return StatusCode(204);
        }
    }