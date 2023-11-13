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

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Pessoa>> Get(string cpf)
        {
            var pessoa = await _pessoaServices.Get(cpf);
            if (pessoa is not null)
                return new ObjectResult(pessoa);
            else
                return NotFound();
        }

        [HttpGet("Count")]
        public async Task<ActionResult<long>> Count()
        {
            return new ObjectResult(await _pessoaServices.Count());
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Create([FromBody] Pessoa pessoa)
        {
            return new ObjectResult(await _pessoaServices.Create(pessoa));
        }
    }
}
