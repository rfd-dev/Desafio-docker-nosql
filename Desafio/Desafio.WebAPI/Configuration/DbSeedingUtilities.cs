using Desafio.Application.Context;
using Desafio.Domain.DomainModels;

namespace Desafio.WebAPI.Configuration
{
    public static class DbSeedingUtilities
    {
        public static void SeedDbForTests(MongoDbContext context)
        {
            context.Pessoas.InsertOneAsync(new Pessoa 
            {
                CPF = "123",
                Nome = "Pessoa teste",
                DataNascimento = new DateOnly(2000, 12, 31),
                Email = "teste@teste.com",
                Id = 1
            });
        }
    }
}
