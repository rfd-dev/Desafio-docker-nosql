namespace Desafio.Business.ViewModels
{
    public class PessoaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
    }
}
