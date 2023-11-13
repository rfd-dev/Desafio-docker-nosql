using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;

namespace Desafio.Application.Services
{
    public interface IPessoaServices
    {
        Task<long> Count();
        Task<PessoaViewModel> Create(Pessoa pessoa);
        Task<PessoaViewModel?> Get(string cpf);
        Task<IEnumerable<PessoaViewModel>> GetAll();
    }
}