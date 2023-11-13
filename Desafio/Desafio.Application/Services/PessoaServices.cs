using Desafio.Application.Repositories;
using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;

namespace Desafio.Application.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaServices(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<PessoaViewModel>> GetAll()
        {
            var pessoas = await _pessoaRepository
                .GetAll();
            return pessoas.Select(p => new PessoaViewModel(p));
        }

        public async Task<PessoaViewModel> Get(long id)
        {
            var pessoa = await _pessoaRepository.Get(id);
            return new PessoaViewModel(pessoa);
        }

        public async Task<PessoaViewModel> Create(Pessoa pessoa)
        {
            await _pessoaRepository.Create(pessoa);

            return new PessoaViewModel(pessoa);
        }
    }
}
