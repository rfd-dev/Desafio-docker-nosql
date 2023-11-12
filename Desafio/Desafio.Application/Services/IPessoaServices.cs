using Desafio.Domain.DomainModels;

namespace Desafio.Application.Services
{
    public interface IPessoaServices
    {
        Task<Pessoa> Create(Pessoa pessoa);
        Task<Pessoa> Get(long id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}