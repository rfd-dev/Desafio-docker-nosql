using Desafio.Business.DomainModels;
using Desafio.Commons.Options;
using MongoDB.Driver;

namespace Desafio.Application.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(MongoDbOptions options)
        {
            var client = new MongoClient(options.ConnectionString);
            _db = client.GetDatabase(options.Database);
        }

        public IMongoCollection<Pessoa> Pessoas => _db.GetCollection<Pessoa>("Pessoas");
    }
}
