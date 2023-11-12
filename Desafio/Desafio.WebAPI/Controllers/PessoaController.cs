using Desafio.Application.Services;
using Desafio.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebAPI.Controllers
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
