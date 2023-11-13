using Desafio.Domain.ViewModels;
using Desafio.IntegrationTests.WebApplicationFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.IntegrationTests.Controllers.PessoaController
{
    public class GetTests : IClassFixture<MongoContainerWebApplicationFactory<Program>>
    {
        private readonly MongoContainerWebApplicationFactory<Program> _factory;

        public GetTests(MongoContainerWebApplicationFactory<Program> mongoContainerWebApplicationFactory)
        {
            _factory = mongoContainerWebApplicationFactory;
        }

        [Fact]
        public async Task Get_WhenCpfFound_ReturnPessoa()
        {
            // Arrange            
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Pessoa/456");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsAsync<PessoaViewModel>();
            Assert.Equal("irma@teste.com", responseContent.Email);
            Assert.Equal("6551b3cf997751d03efc68cc", responseContent.Id);
            Assert.Equal("456", responseContent.CPF);
        }

        [Fact]
        public async Task Get_WhenCpfNotFound_Return404()
        {
            // Arrange            
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Pessoa/00000");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
