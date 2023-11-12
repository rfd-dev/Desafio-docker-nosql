using Desafio.Business.DomainModels;
using Desafio.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServices _pessoaServices;

        public PessoaController(IPessoaServices pessoaServices)
        {
            _pessoaServices = pessoaServices;
        }

        // GET api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
        {
            return new ObjectResult(await _pessoaServices.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> Get(long id)
        {
            return new ObjectResult(await _pessoaServices.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post([FromBody] Pessoa pessoa)
        {
            return new ObjectResult(await _pessoaServices.Create(pessoa));
        }
    }
}
