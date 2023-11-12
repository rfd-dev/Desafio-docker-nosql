using Desafio.Business.DomainModels;
using Desafio.Business.Interfaces;

namespace Desafio.Business.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaServices(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _pessoaRepository.GetAll();
        }

        public async Task<Pessoa> Get(long id)
        {
            return await _pessoaRepository.Get(id);
        }

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            await _pessoaRepository.Create(pessoa);

            return pessoa;
        }
    }
}
