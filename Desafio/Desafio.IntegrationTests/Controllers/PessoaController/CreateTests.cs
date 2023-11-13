using Desafio.Domain.DomainModels;
using Desafio.Domain.ViewModels;
using Desafio.IntegrationTests.WebApplicationFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.IntegrationTests.Controllers.PessoaController
{
    public class CreateTests : IClassFixture<MongoContainerWebApplicationFactory<Program>>
    {
        private readonly MongoContainerWebApplicationFactory<Program> _factory;

        public CreateTests(MongoContainerWebApplicationFactory<Program> mongoContainerWebApplicationFactory)
        {
            _factory = mongoContainerWebApplicationFactory;
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
            Assert.True(responseContent.Id is not null);
        }
    }
}
