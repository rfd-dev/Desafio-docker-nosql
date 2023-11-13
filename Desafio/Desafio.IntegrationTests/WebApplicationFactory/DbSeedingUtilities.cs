using Desafio.Application.Context;
using Desafio.Domain.DomainModels;

namespace Desafio.IntegrationTests.WebApplicationFactory
{
    public static class DbSeedingUtilities
    {
        public static void SeedDbForTests(MongoDbContext context)
        {
            context.Pessoas.InsertOne(new Pessoa 
            {
                CPF = "123",
                Nome = "Pessoa teste",
                DataNascimento = new DateOnly(2000, 12, 31),
                Email = "teste@teste.com",
                Id = "6551b3cf997751d03efc68cd"
            });

            context.Pessoas.InsertOne(new Pessoa
            {
                CPF = "456",
                Nome = "Irma da pessoa teste",
                DataNascimento = new DateOnly(1999, 1, 1),
                Email = "irma@teste.com",
                Id = "6551b3cf997751d03efc68cc"
            });
        }
    }
}
