using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.UnitTests.Domain.ViewModels
{
    public class PersonViewModelTests
    {
        [Fact]
        public void ToDomain_WhenPopulatedViewModel_ReturnPopulatedDomainModel()
        {
            // Arrange
            var viewModel = new PessoaViewModel
            {
                CPF = "123",
                DataNascimento = new DateOnly(1991, 2, 2),
                Email = "teste@teste.com",
                Nome = "Teste Pessoa",
                Id = 1
            };

            // Act
            var domainModel = viewModel.ToDomain();

            // Assert
            Assert.Equal(viewModel.CPF, domainModel.CPF);
            Assert.Equal(viewModel.DataNascimento, domainModel.DataNascimento);
            Assert.Equal(viewModel.Email, domainModel.Email);
            Assert.Equal(viewModel.Nome, domainModel.Nome);
            Assert.Equal(viewModel.Id, domainModel.Id);
        }

        [Fact]
        public void PersonViewModel_WhenPopulatedDomainModel_ConstructorCreatePopulatedViewModel()
        {
            // Arrange
            var domainModel = new Pessoa
            {
                CPF = "123",
                DataNascimento = new DateOnly(1991, 2, 2),
                Email = "teste@teste.com",
                Nome = "Teste Pessoa",
                Id = 1
            };


            // Act
            var viewModel = new PessoaViewModel(domainModel);

            // Assert
            Assert.Equal(domainModel.CPF, viewModel.CPF);
            Assert.Equal(domainModel.DataNascimento, viewModel.DataNascimento);
            Assert.Equal(domainModel.Email, viewModel.Email);
            Assert.Equal(domainModel.Nome, viewModel.Nome);
            Assert.Equal(domainModel.Id, viewModel.Id);
        }
    }
}
