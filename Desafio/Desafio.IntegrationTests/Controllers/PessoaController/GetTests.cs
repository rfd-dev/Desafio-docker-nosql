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
    }
}
