using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;

namespace Desafio.Application.Services
{
    public interface IPessoaServices
    {
        Task<PessoaViewModel> Create(Pessoa pessoa);
        Task<PessoaViewModel> Get(long id);
        Task<IEnumerable<PessoaViewModel>> GetAll();
    }
}