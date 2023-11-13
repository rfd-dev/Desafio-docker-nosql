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
    }
}
