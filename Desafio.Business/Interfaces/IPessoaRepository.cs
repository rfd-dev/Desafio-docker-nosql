using Desafio.Business.DomainModels;

namespace Desafio.Business.Interfaces
{
    public interface IPessoaRepository
    {
        Task Create(Pessoa todo);
        Task<Pessoa> Get(long id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}
