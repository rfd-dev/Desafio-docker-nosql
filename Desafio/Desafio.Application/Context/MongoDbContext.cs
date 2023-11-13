using Desafio.Commons.Options;
using Desafio.Domain.DomainModels;
using MongoDB.Driver;

namespace Desafio.Application.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(string connectionString, string database)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(database);
        }

        public IMongoCollection<Pessoa> Pessoas => _db.GetCollection<Pessoa>("Pessoas");
    }
}
