using Desafio.IntegrationTests.WebApplicationFactory;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
