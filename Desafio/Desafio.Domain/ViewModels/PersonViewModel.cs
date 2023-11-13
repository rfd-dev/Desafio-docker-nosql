using Desafio.Domain.DomainModels;

namespace Desafio.Domain.ViewModels
{
    public class PessoaViewModel
    {
        public string? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }

        public Pessoa ToDomain()
        {
            return new Pessoa
            {
                Id = this.Id,
                CPF = this.CPF,
                Email = this.Email,
                DataNascimento = this.DataNascimento,
                Nome = this.Nome
            };
        }

        public PessoaViewModel()
        { }
        public PessoaViewModel(Pessoa pessoa)
        {
            this.Id = pessoa.Id;
            this.CPF = pessoa.CPF;
            this.Email = pessoa.Email;
            this.DataNascimento = pessoa.DataNascimento;
            this.Nome = pessoa.Nome;
        }
    }
}
