using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;
using Desafio.IntegrationTests.WebApplicationFactory;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.IntegrationTests.Controllers
{
    public class PessoaControllerTests : IClassFixture<MongoContainerWebApplicationFactory<Program>>
    {
        private readonly MongoContainerWebApplicationFactory<Program> _factory;

        public PessoaControllerTests(MongoContainerWebApplicationFactory<Program> mongoContainerWebApplicationFactory)
        {
            _factory = mongoContainerWebApplicationFactory;
        }

        [Fact]
        public async Task GetAll_ReturnsOnlySeededData()
        {
            // Arrange            
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Pessoa");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsAsync<IEnumerable<PessoaViewModel>>();
            Assert.Equal(2, responseContent.Count());
            Assert.Contains(responseContent, p => p.Email == "teste@teste.com" && p.Id == 1 && p.CPF == "123");
            Assert.Contains(responseContent, p => p.Email == "irma@teste.com" && p.Id == 2 && p.CPF == "456");
        }

        [Fact]
        public async Task Get_WhenIdReceived_ReturnPessoa()
        {
            // Arrange            
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Pessoa/2");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsAsync<PessoaViewModel>();
            Assert.Equal("irma@teste.com", responseContent.Email);
            Assert.Equal(2, responseContent.Id);
            Assert.Equal("456", responseContent.CPF);
        }

        [Fact]
        public async Task Create_WhenNewPessoaReceived_PersistNewPessoa()
        {
            // Arrange
            var client = _factory.CreateClient();
            var pessoa = new Pessoa
            {
                Nome = "Cadastro",
                CPF = "789",
                Email = "cadastro@teste.com",
                DataNascimento = new DateOnly(1994, 5, 18)
            };
            var serializedBody = JsonSerializer.Serialize(pessoa);
            var stringContent = new StringContent(serializedBody, Encoding.UTF8, "application/json");

            // Act
            var httpResponse = await client.PostAsync("/Pessoa", stringContent);

            // Assert
            httpResponse.EnsureSuccessStatusCode();
            var responseContent = await httpResponse.Content.ReadAsAsync<PessoaViewModel>();
            Assert.Equal(3, responseContent.Id);
        }
    }
}
