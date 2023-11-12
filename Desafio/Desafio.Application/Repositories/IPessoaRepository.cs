using Desafio.Domain.DomainModels;

namespace Desafio.Application.Repositories
{
    public interface IPessoaRepository
    {
        Task Create(Pessoa pessoa);
        Task<Pessoa> Get(long id);
        Task<IEnumerable<Pessoa>> GetAll();
        Task<long> GetNextId();
    }
}