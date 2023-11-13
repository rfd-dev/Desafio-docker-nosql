using Desafio.Domain.DomainModels;

namespace Desafio.Application.Repositories
{
    public interface IPessoaRepository
    {
        Task Create(Pessoa pessoa);
        Task<Pessoa> Get(string id);
        Task<IEnumerable<Pessoa>> GetAll();
        Task<long> Count();
    }
}