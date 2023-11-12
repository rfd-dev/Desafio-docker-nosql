using Desafio.Business.DomainModels;

namespace Desafio.Business.Services
{
    public interface IPessoaServices
    {
        Task<Pessoa> Create(Pessoa pessoa);
        Task<Pessoa> Get(long id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}